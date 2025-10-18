using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6prak
{
    class Auto
    {
        public string nosaukums;
        public double dzineja_tilp;
        //private double derigstilp;

        public Auto(string nosaukums, double derigstilp)
        {
            this.nosaukums = nosaukums;
            this.dzineja_tilp = derigstilp;
        }
    }
    class Gramata
    {
        public string nosaukums;
        public int lpp_skaits;
        //private string ievadlpp;

        public Gramata(string nosaukums, int derigslpp)
        {
            this.nosaukums = nosaukums;
            this.lpp_skaits = derigslpp;
        }
    }
    internal class Program
    {
        static void PrintDict(Dictionary<string, Auto> dict)
        {
            int index = 0;
            foreach (var item in dict)
            {
                Console.WriteLine("===========");
                Console.WriteLine($"Auto numurs(key): {item.Key}");
                Console.WriteLine($"Auto nosaukums: {item.Value.nosaukums}");
                Console.WriteLine($"Auto motoru tilpums: {item.Value.dzineja_tilp}");
                Console.WriteLine($"Index: {index}");
                //foreach (var cars in dict.Values)
                //{
                //    Console.WriteLine($"Auto nosaukums: {cars.nosaukums}");
                //    Console.WriteLine($"Auto Tilpums: {cars.dzineja_tilp}");
                //}
                index++;
            }
            Console.WriteLine("===========");
            Console.WriteLine($"Elementu skaits: {dict.Count}");
            Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
            Console.ReadKey();
            Console.Clear();
        }
        static void PrintHash(Hashtable ht)
        {
            foreach (DictionaryEntry item in ht)
            {
                Console.WriteLine("===========");
                Console.WriteLine($"Grāmatu autors (key): {item.Key}");

                Gramata gramatuinfo = (Gramata)item.Value;

                Console.WriteLine($"Grāmatu nosaukums: {gramatuinfo.nosaukums}");
                Console.WriteLine($"Grāmatu lapas skaits: {gramatuinfo.lpp_skaits}");
            }
        }
        static void Hash()
        {
            bool stophash = false;
            Hashtable ht = new Hashtable();
            while (!stophash)
            {
                Console.WriteLine("===== HASHTABLE =====");
                Console.WriteLine("1 - Pievieno jaunu grāmatu");
                Console.WriteLine("2 - Izdzēst kādu elementu");
                Console.WriteLine("3 - Attēlo hashtable");
                Console.WriteLine("4 - Izvadīt konkrēto ierakstu pēc autora (key)");
                Console.WriteLine("5 - Iztīrīt hashtable");
                Console.WriteLine("6 - Pāriet atpakaļ uz Dictionary");
                Console.Write("\nTava izvēle:");
                string opcija = Console.ReadLine();
                if (!int.TryParse(opcija, out int derigs))
                {
                    Console.WriteLine("Nav ievadīts cipars");
                    Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    switch (derigs)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Ievadi grāmata autoru: ");
                            string ievadautors = Console.ReadLine();

                            if (ht.ContainsKey(ievadautors))
                            {
                                Console.WriteLine("Šis autors jau ir pievienots");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                Console.Write("\nIevadi grāmatu nosaukumu: ");
                                string nosaukums = Console.ReadLine();
                                Console.Write("\nIevadi lappaspušu skaitu: ");
                                string ievadlpp = Console.ReadLine();
                                if (!int.TryParse(ievadlpp, out int derigslpp))
                                {
                                    Console.WriteLine("Nav ievadīts veselais cipars!");
                                    Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                    Console.ReadKey();
                                    Console.Clear();
                                    return;
                                }
                                else
                                {
                                    ht.Add(ievadautors, new Gramata(nosaukums, derigslpp));
                                    Console.WriteLine("Grāmata pievienota sarakstā");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                            break;
                        case 2:
                            if (ht.Count == 0)
                            {
                                Console.WriteLine("Hashtable ir tukša");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                PrintHash(ht);

                                Console.Write("\nIevadi autoru kuru vēlies izdzēst: ");
                                string autors = Console.ReadLine();

                                if (!ht.ContainsKey(autors))
                                {
                                    Console.WriteLine("Tāds autors hashtable sarakstā nav");
                                    Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    ht.Remove(autors);
                                    Console.WriteLine("Autors noņemts no hash saraksta");
                                    Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                            break;
                        case 3:
                            if (ht.Count == 0)
                            {
                                Console.WriteLine("Hashtable ir tukša");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                PrintHash(ht);
                                Console.WriteLine("===========");
                                Console.WriteLine($"Elementu skaits: {ht.Count}");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 4:
                            if (ht.Count == 0)
                            {
                                Console.WriteLine("Hashtable ir tukša");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write("Ievadi autoru pēc kura meklēt: ");
                                string meklautoru = Console.ReadLine();
                                if (!ht.ContainsKey(meklautoru))
                                {
                                    Console.WriteLine("Tāds autors hashtable sarakstā nav");
                                    Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine($"Autora {meklautoru} grāmatu informācija: ");
                                    Gramata gramatuinfo = (Gramata)ht[meklautoru];
                                    Console.WriteLine($"Grāmatu nosaukums: {gramatuinfo.nosaukums}");
                                    Console.WriteLine($"Grāmatu lapu skaits: {gramatuinfo.lpp_skaits}");
                                }
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 5:
                            if (ht.Count == 0)
                            {
                                Console.WriteLine("Hashtable ir tukša");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                ht.Clear();
                                Console.WriteLine("Hashtable iztīrīta");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 6:
                            Console.Clear();
                            stophash = true;
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
        static void Main(string[] args)
        {
            bool stop = false;
            Dictionary<string, Auto> dict = new Dictionary<string, Auto>();
            while (!stop)
            {
                Console.WriteLine("===== DICTIONARY =====");
                Console.WriteLine("1 - Pievieno jaunu auto");
                Console.WriteLine("2 - Izdzēst kādu elementu");
                Console.WriteLine("3 - Attēlo dictionary");
                Console.WriteLine("4 - Pārkopē keys uz sarakstu un attēlo");
                Console.WriteLine("5 - Pārkopē value uz sarakstu un attēlo");
                Console.WriteLine("6 - Izvadīt dictionary vērtības pēc indeksa");
                Console.WriteLine("7 - Izdzēst dictionary");
                Console.WriteLine("8 - Pāriet uz Hashtable");
                Console.WriteLine("0 - Beigt darbību");

                Console.Write("\nTava izvēle:");
                string opcija = Console.ReadLine();
                if (!int.TryParse(opcija, out int derigs))
                {
                    Console.WriteLine("Nav ievadīts cipars");
                    Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
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
                            Console.WriteLine("Ievadi auto numuru(key): ");
                            string num = Console.ReadLine();

                            if (dict.ContainsKey(num))
                            {
                                Console.WriteLine("Šis auto jau ir pievienots");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                
                                Console.WriteLine("Ievadi auto nosaukumu:");
                                string nosaukums = Console.ReadLine();
                                Console.WriteLine("Ievadi motora tilpumu: ");
                                string tilpums = Console.ReadLine();
                                if (!double.TryParse(tilpums, out double derigstilp))
                                {
                                    Console.WriteLine("Nav ievadīts cipars!");
                                    Console.ReadKey();
                                    return;
                                }
                                else
                                {
                                  
                                    dict.Add(num,new Auto(nosaukums, derigstilp));
                                    Console.WriteLine("Auto pievienots sarakstā");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                               
                            break;
                        case 2:
                            if (dict.Count == 0)
                            {
                                Console.WriteLine("Dictionary ir tukša");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Ievadi numuru(key) pēc kura dzēst: ");
                                string key = Console.ReadLine();
                                if (dict.ContainsKey(key))
                                {
                                    dict.Remove(key);
                                    Console.WriteLine($"Ieraksts pēc key {key} izdzēsta");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("Ieraksts pēc tāda key neeksistē sarakstā");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                            break;
                        case 3:
                            if (dict.Count == 0)
                            {
                                Console.WriteLine("Dictionary ir tukša");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                PrintDict(dict);
                            }
                            break;
                        case 4:
                            if (dict.Count == 0)
                            {
                                Console.WriteLine("Dictionary ir tukša");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Sarakstu keys elementi: ");
                                List<string> keylist = new List<string>(dict.Keys);
                                foreach (var items in keylist)
                                {
                                    Console.WriteLine(items);
                                }
                                Console.WriteLine($"Elementi kopā: {keylist.Count}");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 5:
                            if (dict.Count == 0 )
                            {
                                Console.WriteLine("Dictionary ir tukša");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Sarakstu values elementi: ");
                                List<Auto> valuelist = new List<Auto>(dict.Values);
                                foreach (var items in valuelist)
                                {
                                    Console.WriteLine(items.nosaukums);
                                    Console.WriteLine(items.dzineja_tilp);
                                }
                                Console.WriteLine($"Elementi kopā: {valuelist.Count}");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 6:
                            if (dict.Count == 0)
                            {
                                Console.WriteLine("Dictionary ir tukša");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                try
                                {
                                    Console.Clear();
                                    Console.Write("\nIevadi indeksu pēc kura meklēt: ");
                                    string search = Console.ReadLine();
                                    if (!int.TryParse(search, out int index))
                                    {
                                        Console.WriteLine("Tev ir jāievada cipars");
                                        Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        if (index < 0 || index > dict.Count)
                                        {
                                            Console.WriteLine("Index atrodas ārpus robežām");
                                            Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                            Console.ReadKey();
                                            Console.Clear();
                                        }
                                        else
                                        {
                                            var saturs = dict.ElementAt(index);
                                            //Console.WriteLine($"Izvēlētais index: {index}");
                                            Console.WriteLine($"Auto numurs: {saturs.Key}");
                                            Console.WriteLine($"Auto nosaukums: {saturs.Value.nosaukums}");
                                            Console.WriteLine($"Motora tilpums: {saturs.Value.dzineja_tilp}");

                                            Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                            Console.ReadKey();
                                            Console.Clear();
                                        }

                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Nederīgs index");
                                    break;
                                }
                            }
                            break;
                        case 7:
                            if (dict.Count == 0)
                            {
                                Console.WriteLine("Dictionary ir tukša");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                dict.Clear();
                                Console.WriteLine("Dictionary iztīrīta.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 8:
                            Console.Clear();
                            Hash();
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
    }
}
