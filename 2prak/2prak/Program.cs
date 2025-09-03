using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _2prak
{
    internal class Program
    {
        // Nodefinēts saraksts sākumā, citādi nevar tai piekļūt starp funkcijām.
        static ArrayList arlist = new ArrayList();
        static void Main(string[] args)
        {
            bool stop = false;
            Console.WriteLine("Sveicināti! Izvēlieties savu vēlamo darbību.");
            while (!stop)
            {
                Console.WriteLine("1 - Pievienot sarakstā jaunu elementu.");
                Console.WriteLine("2 - Dzēst sarakstā kādu elementu.");
                Console.WriteLine("3 - Veikt citas izmaiņas esošā sarakstā.");
                Console.WriteLine("0 - Iziet");
                Console.Write("Izvēlētā opcija: ");
                int opcija = int.Parse(Console.ReadLine());
                switch (opcija)
                {
                    case 1:
                        pievienoVert_parbaude();
                        break;
                    case 2:
                        dzestVert();
                        break;
                    case 3:
                        izmainitSaraksti();
                        break;
                    case 0:
                        Console.WriteLine("Darbība tiek apturēta.");
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Tādas opcijas nav.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        static void izmainitSaraksti()
        {
            if (arlist.Count != 0)
            {
                Console.Clear();
                bool editstop = false;
                while (!editstop)
                {
                    Console.WriteLine("Izvēlies darbību:");
                    Console.WriteLine("1 - Sakārtot sarakstu augošā secībā");
                    Console.WriteLine("2 - Sakārtot sarakstu dilstošā secībā");
                    Console.WriteLine("3 - Attēlo saraksta vērtības");
                    Console.WriteLine("4 - Atpakaļ");

                    Console.Write("\nIzvēlētā darbība: ");
                    int edit = int.Parse(Console.ReadLine());
                    switch (edit)
                    {
                        case 1:
                            arlist.Sort();
                            break;
                        case 2:
                            arlist.Reverse();
                            break;
                        case 3:
                            foreach (int l in arlist)
                            {
                                Console.WriteLine(l);
                            }
                            Console.WriteLine($"Saraksts satur {arlist.Count} elementus");
                            Console.WriteLine($"Saraksts norezervē {arlist.Capacity} atmiņu elementiem");
                            if (arlist.IsReadOnly)
                            {
                                Console.WriteLine("Saraksts nav maināms");
                            }
                            else
                            {
                                Console.WriteLine("Saraksts ir maināms");
                            }

                            if (!arlist.IsFixedSize)
                            {
                                Console.WriteLine("Saraksts ir dinamisks");
                            }
                            else
                            {
                                Console.WriteLine("Saraksts nav dinamisks.");
                            }

                            break;
                        case 4:
                            editstop = true;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Tādas opcijas nav.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Saraksts ir tukšs. Darbība apturēta!");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void pievienoVert_parbaude()
        {
            if (arlist.Count == 0)
            {
                pievienoVert();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Saraksts eksistē ar elementiem.");
                Console.WriteLine("Ja vēlaties pievienot jaunas vērtības, ir ieteicams veco sarakstu iztīrīt, lai nav problēmas pievienošanā.");
                Console.WriteLine("To var izdarīt nospiežot taustiņu 2 pie galvenās izvēlnes");
                Console.WriteLine("Ir iespējams papildināt veco sarakstu ar jauniem elementiem, tikai tas var izraisīt neierastas kļūdas.");
                Console.WriteLine("\nVai turpināt? (True/False)");
                Console.Write("\nIzvēlētā darbība: ");
                bool atbilde = bool.Parse(Console.ReadLine());
                if (atbilde)
                {
                    pievienoVert();
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        static void pievienoVert()
        {
            Console.Clear();
            bool stopadd = false;
            while (!stopadd)
            {
                Console.Clear();
                Console.WriteLine("Norādiet kādu veida pievienošanas darbību vēlaties veikt.");
                Console.WriteLine("1 - Pievienot noteiktu elementu skaitu pēc kārtas");
                Console.WriteLine("2 - Pievienot elementu konkrētā vietā");
                Console.WriteLine("3 - Pievienot elementu kopu konkrētā vietā");
                Console.WriteLine("4 - Pievienot elementu kopu sarakstu beigās");
                Console.WriteLine("5 - Atpakaļ");
                Console.Write("\nIzvēlētā darbība: ");
                int darbiba = int.Parse(Console.ReadLine());
                switch (darbiba)
                {
                    case 1: // Pievieno noteiktu elementu skaitu pēc kārtas
                        Console.WriteLine("Cik elementus vēlaties pievienot?");
                        Console.Write("\nVēlamo elementu skaits: ");
                        int skaits = int.Parse(Console.ReadLine());
                        for (int i = 0; i < skaits; i++)
                        {
                            Console.WriteLine("Ievadiet elementu: ");
                            string elements = Console.ReadLine();
                            int derigsElements;

                            bool veiksmigi = int.TryParse(elements, out derigsElements);

                            if (veiksmigi)
                            {
                                arlist.Add(derigsElements);
                            }
                            else
                            {
                                Console.WriteLine("Elements nav int tipa.");
                                i--;
                            }
                        }
                        Console.WriteLine("Vērtības pievienotas. Spied jebkuru pogu, lai izietu.");
                        Console.ReadKey();
                        break;
                    case 2: // Pievieno elementu konkrētā vietā
                        Console.Write("\nIerakstiet elementu kuru vēlaties pievienot:");
                        string element = Console.ReadLine();

                        int derigsElement;
                        bool veiksmigs = int.TryParse(element, out derigsElement);

                        Console.Write("\nNorādiet vietu (index) kur vēlaties pievienot elementu sarakstā: ");
                        string range = Console.ReadLine();

                        int derigsRange;
                        bool veiksmigsRange = int.TryParse(range, out derigsRange);

                        if (veiksmigs && veiksmigsRange)
                        {
                            arlist.Insert(derigsRange, derigsElement);
                            Console.WriteLine($"Elements {derigsElement} ir pievienots ar index Nr.{derigsRange}");
                            Console.WriteLine("Spiediet jebkuru pogu, lai ietu atpakaļ uz izvēlni");
                            Console.ReadKey();
                        }
                        else if (!veiksmigs || !veiksmigsRange)
                        {
                            Console.WriteLine("Elements nav int tipa, vai arī norādīta nederīga vieta");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Nav norādīti elementi un vieta.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 3: 
                        // Pievieno elementu kopu konkrētā vietā
                        // Pagaidu saraksts
                        ArrayList tempList = new ArrayList();
                        Console.WriteLine("Norādiet index: ");
                        string index1 = Console.ReadLine();
                        bool derigsIndex1;
                        int derigs1;
                        derigsIndex1 = int.TryParse(index1, out derigs1);

                        if(!derigsIndex1)
                        {
                            Console.WriteLine("Norādītais index nav derīgs.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Cik elementus vēlaties pievienot?");
                            Console.Write("\nVēlamo elementu skaits: ");
                            int skaitsKopa = int.Parse(Console.ReadLine());
                            bool veiksmigsElementsKopa;
                            for (int i = 0; i < skaitsKopa; i++)
                            {
                                Console.Write("\nNorādiet elementu: ");
                                string elementsKopa = Console.ReadLine();

                                // Pārbaude
                                int derigsElementsKopa;
                                veiksmigsElementsKopa = int.TryParse(elementsKopa, out derigsElementsKopa);

                                if (veiksmigsElementsKopa)
                                {
                                    tempList.Add(derigsElementsKopa);
                                }
                                else
                                {
                                    Console.WriteLine("Elements nav int tipa.");
                                    i--;
                                }
                            }
                            arlist.InsertRange(derigs1, tempList);
                            Console.WriteLine("Vērtības pievienotas. Spied jebkuru pogu, lai izietu.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 4:
                        // Pievieno elementu kopu sarakstu beigās
                        // Pagaidu saraksts
                        ArrayList tempList1 = new ArrayList();
                        Console.WriteLine("Cik elementus vēlaties pievienot?");
                        Console.Write("\nVēlamo elementu skaits: ");
                        int skaitsKopa1 = int.Parse(Console.ReadLine());
                        bool veiksmigsElementsKopa1;
                        for (int i = 0; i < skaitsKopa1; i++)
                        {
                            Console.Write("\nNorādiet elementu: ");
                            string elementsKopa1 = Console.ReadLine();

                            // Pārbaude
                            int derigsElementsKopa1;
                            veiksmigsElementsKopa1 = int.TryParse(elementsKopa1, out derigsElementsKopa1);

                            if (veiksmigsElementsKopa1)
                            {
                                tempList1.Add(derigsElementsKopa1);
                            }
                            else
                            {
                                Console.WriteLine("Elements nav int tipa.");
                                i--;
                            }
                        }
                        arlist.AddRange(tempList1);
                        Console.WriteLine("Vērtības pievienotas. Spied jebkuru pogu, lai izietu.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        stopadd = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Tādas opcijas nav.");
                        break;
                }
            }
        }
        
        static void dzestVert()
        {
            if (arlist.Count != 0)
            {
                bool stopdel = false;
                while (!stopdel)
                {
                    Console.Clear();
                    foreach (int ar in arlist)
                    {
                        Console.WriteLine(ar);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Izvēlieties savu darbību:");
                    Console.WriteLine("1 - Dzēst pēc indeksa");
                    Console.WriteLine("2 - Dzēst noteiktu elementu sarakstā");
                    Console.WriteLine("3 - Iztīrīt visu sarakstu");
                    Console.WriteLine("4 - Izdzēst pēc noteikta apgabala");
                    Console.WriteLine("5 - Atpakaļ");
                    Console.Write("Vēlamā opcija: ");
                    int delOpc = int.Parse(Console.ReadLine());

                    switch (delOpc)
                    {
                        case 1: // Dzēst pēc indeksa
                            try
                            {
                                Console.Write("\nIevadiet indeksu: ");
                                string index = Console.ReadLine();
                                int derigs;
                                bool derigsIndex = int.TryParse(index, out derigs);
                                if (!derigsIndex)
                                {
                                    Console.WriteLine("Tāds index neeksistē");
                                }
                                else if (derigs > arlist.Count || arlist.Contains(null))
                                {
                                    Console.WriteLine("Index nedrīkst būt lielāks par elementu skaitu un/vai null!");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    arlist.RemoveAt(derigs);
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Index ir negatīvs un/vai neeksistē. Darbība apturēta!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            break;
                        case 2: // Dzēst pēc elementa.
                            Console.WriteLine("Norādiet elementu dzēšanai.");
                            Console.Write("\nNorādītais elements: ");
                            string elements = Console.ReadLine();
                            int derigsElements;

                            bool veiksmigi = int.TryParse(elements, out derigsElements);
                            if (!veiksmigi)
                            {
                                Console.WriteLine("Noradītais elements nav int tipa.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (!arlist.Contains(derigsElements))
                            {
                                Console.WriteLine("Sarakstā nav šāda elementa.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                arlist.Remove(derigsElements);
                                Console.WriteLine($"Norādītais elements {derigsElements} ir noņemts no saraksta.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 3: // Iztīra visu listi.
                            if (arlist.Count != 0)
                            {
                                arlist.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Liste neeksistē!");
                            }
                            break;
                        case 4: // Iztīra pēc norādītā apgabala.
                            try
                            {
                                Console.Write("\nIevadiet sākuma index vērtību apgabalam: ");
                                string startRange = Console.ReadLine();
                                Console.Write("\nIevadiet beigu index vērtību apgabalam: ");
                                string endRange = Console.ReadLine();

                                // Pārbauda vai ir int tipa. Tas ir lai novērstu programmu avārijas un iespējamās kļūdas.

                                int derigsStart;
                                int derigsEnd;

                                bool veiksmigsStart = int.TryParse(startRange, out derigsStart);
                                bool veiksmigsEnd = int.TryParse(endRange, out derigsEnd);

                                if (veiksmigsStart && veiksmigsEnd)
                                {
                                    arlist.RemoveRange(derigsStart, derigsEnd);
                                    Console.WriteLine($"Elementi ar index sākot ar {derigsStart} un beidzot ar {derigsEnd} noņemti.");
                                    Console.WriteLine("Spiediet jebkuru pogu, lai ietu atpakaļ uz izvēlni");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else 
                                {
                                    Console.WriteLine("Norādītais apgabals nesatur skaitļus! Darbība nav iespējama");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Norādītais apgabals satur skaitļus kuri sarakstā ir negatīvi un/vai neeksistē. Darbība apturēta!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            break;
                        case 5:
                            stopdel = true;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Tādu opciju nav.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Saraksts neeksistē. Izveidojiet sarakstu nospiežot taustiņu 1 pie galvenās izvēlnes. Darbība apturēta!");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
