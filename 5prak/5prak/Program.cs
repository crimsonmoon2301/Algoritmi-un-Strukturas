using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace _5prak
{
    enum Maksajuma_veids
    {
        Skaidra,
        Karte,
        Paypal,
        Parskaitijums
    }
    class Maksajums
    {
        public double summa;
        public Maksajuma_veids veids;
    }
    enum Pilseta
    {
        Jelgava,
        Riga,
        Olaine,
        Rezekne,
        Liepaja
    }
    class Piegade
    {
        public string adrese;
        public Pilseta pilseta;
    }
    enum Statuss
    {
        Pienemts,
        Nosutits,
        Izpildits
    }
    class Pasutijums
    {
        public DateTime datums;
        public Statuss pasut_statuss;
        public Piegade piegade;
        public Maksajums maksajums;
    }

    class Persona
    {
        public string vards;
        public string uzvards;
    }
    class Lietotajs : Persona
    {
        public string lietotajvards;
        protected string parole;
    }
    class Klients : Lietotajs
    {
        public string epasts;
        public Pasutijums[] pasutijumi;

        public string ParolesIevade()
        {
            Console.Write("\nIevadi paroli: ");
            parole = Console.ReadLine();
            return parole;
        }
    }
    internal class Program
    {
        // Jāizpēta vai nevar šo vienkāršot.
        static void PievienoElem(List<Klients> saraksts)
        {
            Console.Clear();
            Klients klients = new Klients();
            Console.Write("\nIevadi klienta lietotājvārdu: ");
            klients.lietotajvards = Console.ReadLine();
            klients.ParolesIevade(); // Protected instancēm var tikt klāt tikai caur mantojamo klasi.

            Console.Write("\nIevadi klienta vārdu: ");
            klients.vards = Console.ReadLine();
            Console.Write("\nIevadi klienta uzvārdu: ");
            klients.uzvards = Console.ReadLine();
            Console.Write("\nIevadi klienta epastu: ");
            klients.epasts = Console.ReadLine();

            Console.Write("\nIevadi pasūtījumu skaitu: ");
            string skaits = Console.ReadLine();
            if (!int.TryParse(skaits, out int derigs))
            {
                Console.WriteLine("Nav ievadīts skaitlis");
                Console.ReadKey();
                return;
            }
            else
            {
                klients.pasutijumi = new Pasutijums[derigs];

                for (int i = 0; i < derigs; i++)
                {
                    klients.pasutijumi[i] = new Pasutijums();
                    klients.pasutijumi[i].piegade = new Piegade();


                    int pilssk = 0;
                    Console.WriteLine($"Pasūtījuma ID: {i}");

                    // Izveido objektus priekš pasūtījuma
                    //Pasutijums pasut = new Pasutijums();

                    Console.Write("\nIevadi pasūtijuma adresi: ");
                    klients.pasutijumi[i].piegade.adrese = Console.ReadLine();
                    Console.Write("\nPieejamās pilsētas:\n ");
                    foreach (Pilseta p in Enum.GetValues(typeof(Pilseta)))
                    {
                        Console.WriteLine(p);
                    }
                    Console.WriteLine("0 - Jelg; 1 - Riga; 2 - Olaine; 3 - Rezekne; 4 - Liepaja");
                    Console.WriteLine("\nIzvēlētā pilsēta: ");
                    string pilseta = Console.ReadLine();
                    if (!int.TryParse(pilseta, out int pilscip))
                    {
                        Console.WriteLine("Nav ievadīts cipars!");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        string izveleta;
                        switch (pilscip)
                        {
                            case 0:
                                klients.pasutijumi[i].piegade.pilseta = Pilseta.Jelgava;
                                Console.WriteLine($"Izvēlēta pilsēta: {klients.pasutijumi[i].piegade.pilseta}");
                                break;
                            case 1:
                                klients.pasutijumi[i].piegade.pilseta = Pilseta.Riga;
                                Console.WriteLine($"Izvēlēta pilsēta: {klients.pasutijumi[i].piegade.pilseta}");
                                break;
                            case 2:
                                klients.pasutijumi[i].piegade.pilseta = Pilseta.Olaine;
                                Console.WriteLine($"Izvēlēta pilsēta: {klients.pasutijumi[i].piegade.pilseta}");
                                break;
                            case 3:
                                klients.pasutijumi[i].piegade.pilseta = Pilseta.Rezekne;
                                Console.WriteLine($"Izvēlēta pilsēta: {klients.pasutijumi[i].piegade.pilseta}");
                                break;
                            case 4:
                                klients.pasutijumi[i].piegade.pilseta = Pilseta.Liepaja;
                                Console.WriteLine($"Izvēlēta pilsēta: {klients.pasutijumi[i].piegade.pilseta}");
                                break;
                            default:
                                Console.WriteLine("Tādu ciparu nav!");
                                Console.ReadKey();
                                break;
                        }
                    }
                }
                saraksts.Add(klients);
            }
        }

        static void Main(string[] args)
        {
            bool stop = false;
            List<Klients> saraksts = new List<Klients>();
            while (!stop)
            {
                Console.WriteLine("1 - Pievienot jaunu elementu sarakstam");
                Console.WriteLine("2 - Dzēst elementu pēc klienta vārda");
                Console.WriteLine("3 - Sakārtot sarakstu"); // Pievienots
                Console.WriteLine("4 - Dzēst elementu pēc indeksa");
                Console.WriteLine("5 - Pievienot jaunu elementu konkrētā vietā");
                Console.WriteLine("6 - Attēlot saraksta vērtības"); // Pievienots
                Console.WriteLine("7 - Parādīt sarakstu");
                Console.WriteLine("0 - Beigt darbību"); // Pievienots
               
                Console.Write("\nTava izvēle: ");
                string izvele = Console.ReadLine();
                if (!int.TryParse(izvele, out int derigs))
                {
                    Console.WriteLine("Nav ievadīts cipars!");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    switch (derigs)
                    {
                        case 1:
                            PievienoElem(saraksts);
                            break;
                        case 3:
                            if (saraksts.Count == 0)
                            {
                                Console.WriteLine("Saraksts ir tukšs!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                saraksts.Sort();
                                Console.WriteLine("Saraksts sakārtots");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 6:
                            if (saraksts.Count == 0)
                            {
                                Console.WriteLine("Saraksts ir tukšs!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                int skaits = saraksts.Count();
                                int kapacitate = saraksts.Capacity;
                                Console.Write($"Elementu skaits sarakstā:{skaits} ");
                                Console.Write($"\nSarakstu kapacitāte: {kapacitate}");
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 7: // Tiks papildināts.
                            if (saraksts.Count == 0)
                            {
                                Console.WriteLine("Saraksts ir tukšs!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                foreach (Klients item in saraksts)
                                {
                                    Console.WriteLine("===== KLIENTS =====");
                                    Console.WriteLine($"Klienta vārds: {item.vards}");
                                    Console.WriteLine($"Klienta uzvārds: {item.uzvards}");
                                    Console.WriteLine($"Klienta lietotājvārds: {item.lietotajvards}");
                                    //Console.WriteLine($"Klienta parole: {item.ParolesIevade()}");
                                    Console.WriteLine($"Klienta epasts: {item.epasts}");
                                    Console.WriteLine("===== INFO PAR PASŪTĪJUMU =====");
                                    foreach (var pasut in item.pasutijumi)
                                    {
                                        Console.WriteLine($"Piegādes adrese: {pasut.piegade.adrese}");
                                        Console.WriteLine($"Piegādes pilsēta: {pasut.piegade.pilseta}");
                                        Console.WriteLine("====================");
                                    }

                                }
                            }
                            break;
                        case 0:
                            stop = true;
                            break;
                        default:
                            Console.WriteLine("Tādas opcijas nav!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }
        }
    }
}