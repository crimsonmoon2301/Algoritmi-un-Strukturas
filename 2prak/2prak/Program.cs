using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        pievienoVert();
                        break;
                    case 2:
                        dzestVert();
                        break;
                    case 3:
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
        static void pievienoVert()
        {
            if (arlist.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Cik vērtības vēlaties pievienot?\n");
                Console.Write("\nVēlamo vērtību skaits: ");
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
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Saraksts eksistē ar elementiem.");
                Console.WriteLine("Ja vēlaties pievienot jaunas vērtības, iztīriet veco sarakstu. To var izdarīt nospiežot taustiņu 2 pie galvenās izvēlnes. Darbība apturēta!");
                Console.ReadKey();
                Console.Clear();
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

                    Console.WriteLine("Izvēlieties savu darbību: ");
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
                        case 2: // Dzēst pēc elementa. TODO
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
                        case 4: // Iztīra pēc norādītā apgabala. TODO
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
