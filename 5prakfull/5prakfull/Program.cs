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
                    klients.pasutijumi[i].maksajums = new Maksajums();
                    klients.pasutijumi[i].pasut_statuss = new Statuss();
                    //klients.pasutijumi[i].pasut_statuss = new Statuss();

                    int pilssk = 0;
                    Console.WriteLine($"Pasūtījuma ID: {i+1}");

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
                    Console.Clear();
                    Console.Write("\nNorādi pasūtījuma datumu: ");
                    klients.pasutijumi[i].datums = DateTime.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.Write("\nNorādi pasūtījuma summu: ");
                    klients.pasutijumi[i].maksajums.summa = double.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Norādi apmaksājuma veidu: ");
                    foreach (Maksajuma_veids mv in Enum.GetValues(typeof(Maksajuma_veids)))
                    {
                        Console.WriteLine(mv);
                    }
                    Console.WriteLine("0 - Skaidrā nauda, 1 - Maksājumu karte, 2 - PayPal, 3 - Banku pārskaitījums");
                    string maksveid = Console.ReadLine();
                    if (!int.TryParse(maksveid, out int derigsmaksveid))
                    {
                        Console.WriteLine("Tev ir jānorāda cipars");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        string izveleta;
                        switch (derigsmaksveid)
                        {
                            case 0:
                                klients.pasutijumi[i].maksajums.veids = Maksajuma_veids.Skaidra;
                                Console.WriteLine($"Izvēlētais maksājuma veids: {klients.pasutijumi[i].maksajums.veids}");
                                break;
                            case 1:
                                klients.pasutijumi[i].maksajums.veids = Maksajuma_veids.Karte;
                                Console.WriteLine($"Izvēlētais maksājuma veids: {klients.pasutijumi[i].maksajums.veids}");
                                break;
                            case 2:
                                klients.pasutijumi[i].maksajums.veids = Maksajuma_veids.Paypal;
                                Console.WriteLine($"Izvēlētais maksājuma veids: {klients.pasutijumi[i].maksajums.veids}");
                                break;
                            case 3:
                                klients.pasutijumi[i].maksajums.veids = Maksajuma_veids.Parskaitijums;
                                Console.WriteLine($"Izvēlētais maksājuma veids: {klients.pasutijumi[i].maksajums.veids}");
                                break;
                            default:
                                Console.WriteLine("Tādu ciparu nav!");
                                Console.ReadKey();
                                break;
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Norādi apmaksājuma statusu: ");
                    foreach (Statuss ass in Enum.GetValues(typeof(Statuss)))
                    {
                        Console.WriteLine(ass);
                    }
                    Console.WriteLine("0 - Pieņemts, 1 - Nosūtīts, 2 - Izpildīts");
                    string status = Console.ReadLine();
                    if (!int.TryParse(status, out int derigsstatus))
                    {
                        Console.WriteLine("Tev ir jāievada cipars");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        switch (derigsstatus)
                        {
                            case 0:
                                klients.pasutijumi[i].pasut_statuss = Statuss.Pienemts;
                                Console.WriteLine($"Izvēlēta statuss: {klients.pasutijumi[i].pasut_statuss}");
                                break;
                            case 1:
                                klients.pasutijumi[i].pasut_statuss = Statuss.Nosutits;
                                Console.WriteLine($"Izvēlēta statuss: {klients.pasutijumi[i].pasut_statuss}");
                                break;
                            case 2:
                                klients.pasutijumi[i].pasut_statuss = Statuss.Izpildits;
                                Console.WriteLine($"Izvēlēta statuss: {klients.pasutijumi[i].pasut_statuss}");
                                break;
                            default:
                                Console.WriteLine("Tādu ciparu nav!");
                                Console.ReadKey();
                                break;
                        }
                    }
                }
            }
            saraksts.Add(klients);
        }
        static void SakartotSar(List<Klients> saraksts)
        {
            Console.Clear();
            bool stopsorting = false;
            while (!stopsorting)
            {
                Console.WriteLine("Kā vēlaties sakārtot sarakstu?");
                Console.WriteLine("1 - Pēc vārda (A-Z)");
                Console.WriteLine("2 - Pēc uzvārda (A-Z)");
                Console.WriteLine("3 - Pēc vārda (Z-A)");
                Console.WriteLine("4 - Pēc uzvārda (Z-A)");

                Console.WriteLine("0 - Iet atpakaļ uz izvēlni");

                Console.Write("\nTava izvēle: ");

                string sortopcija = Console.ReadLine();
                if (!int.TryParse(sortopcija, out int derigs))
                {
                    Console.WriteLine("Tev ir jāievada cipars!");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    switch (derigs)
                    {
                        case 1: // Sakārto vārdus augošā secībā pēc alfabēta (A - Z)
                            saraksts.Sort((a, b) => a.vards.CompareTo(b.vards));
                            break;
                        case 2: // Sakārto uzvārdus pretējā secībā (Z - A) 
                            saraksts.Sort((a, b) => a.uzvards.CompareTo(b.uzvards));
                            break;
                        case 3: // Tas pats kas ar vārdiem, bet šeit ir pretēji
                            saraksts.Sort((a, b) => b.vards.CompareTo(a.vards));
                            break;
                        case 4:
                            saraksts.Sort((a, b) => b.uzvards.CompareTo(a.uzvards));
                            break;
                        case 0:
                            stopsorting = true;
                            break;
                        default:
                            Console.WriteLine("Tāda opcija nav");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }
        }
        static void Print(List<Klients> saraksts)
        {
            int index = 0;
            foreach (Klients klients in saraksts)
            {
                //Console.WriteLine(klients);
                Console.WriteLine("===== KLIENTS =====");
                Console.WriteLine($"Klienta vārds: {klients.vards}");
                Console.WriteLine($"Klienta uzvārds: {klients.uzvards}");
                Console.WriteLine($"Klienta lietotājvārds: {klients.lietotajvards}");
                //Console.WriteLine($"Klienta parole: {item.ParolesIevade()}");
                Console.WriteLine($"Klienta epasts: {klients.epasts}");
                Console.WriteLine($"Index: {index}");
                Console.WriteLine("===== INFO PAR PASŪTĪJUMU =====");
                foreach (var pasut in klients.pasutijumi)
                {
                    Console.WriteLine($"Piegādes adrese: {pasut.piegade.adrese}");
                    Console.WriteLine($"Piegādes pilsēta: {pasut.piegade.pilseta}");
                    Console.WriteLine($"Piegādes datums: {pasut.datums}");
                    Console.WriteLine($"Piegādes status: {pasut.pasut_statuss}");
                    Console.WriteLine("====================");
                    Console.WriteLine($"Apmaksātā summa: {pasut.maksajums.summa}");
                    Console.WriteLine($"Apmaksas veids: {pasut.maksajums.veids}");
                    Console.WriteLine("====================");
                }
                index++;
            }
        }
        static void Main(string[] args)
        {
            bool stop = false;
            List<Klients> saraksts = new List<Klients>();
            while (!stop)
            {
                Console.WriteLine("1 - Pievienot jaunu elementu sarakstam"); // Pievienots
                Console.WriteLine("2 - Dzēst elementu pēc klienta vārda"); // Pievienots.
                Console.WriteLine("3 - Sakārtot sarakstu"); // Pievienots, toties nestrādā
                Console.WriteLine("4 - Dzēst elementu pēc indeksa"); // Pievienots.
                Console.WriteLine("5 - Pievienot jaunu elementu konkrētā vietā");
                Console.WriteLine("6 - Attēlot saraksta vērtības"); // Pievienots
                Console.WriteLine("7 - Parādīt sarakstu"); // Pievienots.
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
                            Console.WriteLine("Elementi pievienoti");
                            Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            if (saraksts.Count == 0)
                            {
                                Console.WriteLine("Saraksts ir tukšs!");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Ievadi vārdu: ");
                                string vards = Console.ReadLine();
                                var klientsv = saraksts.Find(x => x.vards == vards);
                                if (klientsv != null)
                                {
                                    saraksts.Remove(klientsv);
                                    Console.WriteLine("Saraksta ieraksts noņemts");
                                    Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Sarakstā tāds vārds neeksistē");
                                    Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                            break;
                        case 3:
                            if (saraksts.Count == 0)
                            {
                                Console.WriteLine("Saraksts ir tukšs!");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                SakartotSar(saraksts);
                                Console.WriteLine("Saraksts sakārtots");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 4:
                            if (saraksts.Count == 0)
                            {
                                Console.WriteLine("Saraksts ir tukšs!");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Print(saraksts);

                                Console.WriteLine("Ievadi indeksu pēc kura dzēst: ");
                                string index = Console.ReadLine();
                                if (!int.TryParse(index, out int derigsindex))
                                {
                                    Console.WriteLine("Tev ir jāievada cipars");
                                    Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    saraksts.RemoveAt(derigsindex);
                                    Console.WriteLine($"Saraksta elements ar index {derigsindex} izdzēsts");
                                    Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                    Console.ReadKey();
                                }
                            }
                            break;
                        case 5:
                            if (saraksts.Count == 0)
                            {
                                Console.WriteLine("Saraksts ir tukšs!");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Print(saraksts);
                                Console.WriteLine("Ievadi indeksu: ");
                                string index = Console.ReadLine();

                                if (!int.TryParse(index, out int derigsindex))
                                {
                                    Console.WriteLine("Tev ir jāievada index");
                                    Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    if (derigsindex < 0 || derigsindex > saraksts.Count())
                                    {
                                        Console.WriteLine("Indekss ir ārpus robežām");
                                        Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                        Console.ReadKey();
                                        Console.Clear();
                                        return;
                                    }
                                    else
                                    {
                                        //Klients klients = new Klients();
                                        //Console.Write("\nIevadi klienta lietotājvārdu: ");
                                        //klients.lietotajvards = Console.ReadLine();
                                        //klients.ParolesIevade(); // Protected instancēm var tikt klāt tikai caur mantojamo klasi.

                                        //Console.Write("\nIevadi klienta vārdu: ");
                                        //klients.vards = Console.ReadLine();
                                        //Console.Write("\nIevadi klienta uzvārdu: ");
                                        //klients.uzvards = Console.ReadLine();
                                        //Console.Write("\nIevadi klienta epastu: ");
                                        //klients.epasts = Console.ReadLine();
                                        
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
                                        if (!int.TryParse(skaits, out int derigs1))
                                        {
                                            Console.WriteLine("Nav ievadīts skaitlis");
                                            Console.ReadKey();
                                            return;
                                        }
                                        else
                                        {
                                            klients.pasutijumi = new Pasutijums[derigs1];

                                            for (int i = 0; i < derigs1; i++)
                                            {
                                                klients.pasutijumi[i] = new Pasutijums();
                                                klients.pasutijumi[i].piegade = new Piegade();
                                                klients.pasutijumi[i].maksajums = new Maksajums();
                                                klients.pasutijumi[i].pasut_statuss = new Statuss();
                                                //klients.pasutijumi[i].pasut_statuss = new Statuss();

                                                int pilssk = 0;
                                                Console.WriteLine($"Pasūtījuma ID: {i + 1}");

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
                                                Console.Clear();
                                                Console.Write("\nNorādi pasūtījuma datumu: ");
                                                klients.pasutijumi[i].datums = DateTime.Parse(Console.ReadLine());
                                                Console.Clear();
                                                Console.Write("\nNorādi pasūtījuma summu: ");
                                                klients.pasutijumi[i].maksajums.summa = double.Parse(Console.ReadLine());
                                                Console.WriteLine();
                                                Console.WriteLine("Norādi apmaksājuma veidu: ");
                                                foreach (Maksajuma_veids mv in Enum.GetValues(typeof(Maksajuma_veids)))
                                                {
                                                    Console.WriteLine(mv);
                                                }
                                                Console.WriteLine("0 - Skaidrā nauda, 1 - Maksājumu karte, 2 - PayPal, 3 - Banku pārskaitījums");
                                                string maksveid = Console.ReadLine();
                                                if (!int.TryParse(maksveid, out int derigsmaksveid))
                                                {
                                                    Console.WriteLine("Tev ir jānorāda cipars");
                                                    Console.ReadKey();
                                                    break;
                                                }
                                                else
                                                {
                                                    string izveleta;
                                                    switch (derigsmaksveid)
                                                    {
                                                        case 0:
                                                            klients.pasutijumi[i].maksajums.veids = Maksajuma_veids.Skaidra;
                                                            Console.WriteLine($"Izvēlētais maksājuma veids: {klients.pasutijumi[i].maksajums.veids}");
                                                            break;
                                                        case 1:
                                                            klients.pasutijumi[i].maksajums.veids = Maksajuma_veids.Karte;
                                                            Console.WriteLine($"Izvēlētais maksājuma veids: {klients.pasutijumi[i].maksajums.veids}");
                                                            break;
                                                        case 2:
                                                            klients.pasutijumi[i].maksajums.veids = Maksajuma_veids.Paypal;
                                                            Console.WriteLine($"Izvēlētais maksājuma veids: {klients.pasutijumi[i].maksajums.veids}");
                                                            break;
                                                        case 3:
                                                            klients.pasutijumi[i].maksajums.veids = Maksajuma_veids.Parskaitijums;
                                                            Console.WriteLine($"Izvēlētais maksājuma veids: {klients.pasutijumi[i].maksajums.veids}");
                                                            break;
                                                        default:
                                                            Console.WriteLine("Tādu ciparu nav!");
                                                            Console.ReadKey();
                                                            break;
                                                    }
                                                }
                                                Console.Clear();
                                                Console.WriteLine("Norādi apmaksājuma statusu: ");
                                                foreach (Statuss ass in Enum.GetValues(typeof(Statuss)))
                                                {
                                                    Console.WriteLine(ass);
                                                }
                                                Console.WriteLine("0 - Pieņemts, 1 - Nosūtīts, 2 - Izpildīts");
                                                string status = Console.ReadLine();
                                                if (!int.TryParse(status, out int derigsstatus))
                                                {
                                                    Console.WriteLine("Tev ir jāievada cipars");
                                                    Console.ReadKey();
                                                    Console.Clear();
                                                }
                                                else
                                                {
                                                    switch (derigsstatus)
                                                    {
                                                        case 0:
                                                            klients.pasutijumi[i].pasut_statuss = Statuss.Pienemts;
                                                            Console.WriteLine($"Izvēlēta statuss: {klients.pasutijumi[i].pasut_statuss}");
                                                            break;
                                                        case 1:
                                                            klients.pasutijumi[i].pasut_statuss = Statuss.Nosutits;
                                                            Console.WriteLine($"Izvēlēta statuss: {klients.pasutijumi[i].pasut_statuss}");
                                                            break;
                                                        case 2:
                                                            klients.pasutijumi[i].pasut_statuss = Statuss.Izpildits;
                                                            Console.WriteLine($"Izvēlēta statuss: {klients.pasutijumi[i].pasut_statuss}");
                                                            break;
                                                        default:
                                                            Console.WriteLine("Tādu ciparu nav!");
                                                            Console.ReadKey();
                                                            break;
                                                    }
                                                }
                                            }
                                            saraksts.Insert(derigsindex, klients);
                                        }
                                    }
                                }
                            }
                            break;
                        case 6:
                            if (saraksts.Count == 0)
                            {
                                Console.WriteLine("Saraksts ir tukšs!");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                int skaits = saraksts.Count();
                                int kapacitate = saraksts.Capacity;
                                Console.Write($"Elementu skaits sarakstā:{skaits} ");
                                Console.Write($"\nSarakstu kapacitāte: {kapacitate}\n");
                            }
                            Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 7:
                            if (saraksts.Count == 0)
                            {
                                Console.WriteLine("Saraksts ir tukšs!");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Print(saraksts);
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
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