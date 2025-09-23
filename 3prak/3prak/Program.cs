using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _3prak
{
    public class Gramata
    {
        public string nosaukums;
        public string autors;
        public int lppSkaits;

        public void Registret()
        {

            Console.Write("\nIevadi grāmata nosaukumu: ");
            nosaukums = Console.ReadLine();
            Console.Write("Ievadi grāmata autoru: ");
            autors = Console.ReadLine();
            Console.Write("Ievadi grāmata lappušu skaitu: ");
            lppSkaits = Convert.ToInt32(Console.ReadLine());
        }

        public void Izvadit()
        {
            Console.WriteLine($"{nosaukums}, {autors}, {lppSkaits}");
        }
    }
    class MyList
    {
        // Ir atsevišķs saraksts kur ņem grāmatu objektus, vēlākai apstrādei.
        List<Gramata> mylist = new List<Gramata>();
        public void Add(Gramata g)
        {
            g.Registret();
            mylist.Add(g);
        }
        public void Print()
        {
            // Neliela pārbaude.
            if (mylist.Count == 0)
            {
                Console.WriteLine("Saraksts ir tukšs");
                return;
            }
            else
            {
                foreach (Gramata g in mylist)
                {
                    g.Izvadit();
                }
            }
        }
        public int Count()
        {
            // Atgriež skaitu no iebūvētās sarakstes
            return mylist.Count;
        }
        public void insert(int index, Gramata g)
        {
            // Lietotājs ievada indeksu, kas tālāk tiek padots šeit. Pēctam tas tiek padots tālāk iebūvētai sarakstei priekš funkcijas.
            // Nedaudz sarežģīti, bet strādā tīri ok.
            g.Registret();
            mylist.Insert(index, g);
            Console.WriteLine("Grāmata pievienota");
            Console.ReadKey();
            Console.Clear();
        }
        public void Clear()
        {
            // iztīra iekšējo sarakstu ar iebūvēto funkciju. 
            mylist.Clear();
            Console.WriteLine("Saraksts iztīrīts");
            Console.ReadKey();
            Console.Clear();
        }
        public void RemoveAt(int index)
        {
            // Pārbauda indeksu, lai novērstu avārijas.
            if (index < 0 || index >= mylist.Count)
            {
                Console.WriteLine("Nederīgs indekss");
                return;
            }
            // Ja viss ok, tad izdzēs ārā.
            mylist.RemoveAt(index);
            Console.WriteLine("Grāmata izdzēsta");
            Console.ReadKey();
            Console.Clear();
        }
        public Gramata ElementAt(int index)
        {
            Console.WriteLine($"Grāmata ar index {index} ir:");
            Console.WriteLine($"Nosaukums: {mylist.ElementAt(index).nosaukums}");
            Console.WriteLine($"Autors: {mylist.ElementAt(index).autors}");
            Console.WriteLine($"Lappušu skaits: {mylist.ElementAt(index).lppSkaits}");
            return mylist.ElementAt(index);
        }

        public int FirstIndexOf(Gramata g)
        {
            Console.WriteLine($"Pirmā grāmata sarakstā ir: {mylist.First().nosaukums}, {mylist.First().autors}, {mylist.First().lppSkaits}");
            Console.WriteLine($"Ar indeksu nr: {mylist.IndexOf(mylist.First())}"); // sakombinētas divas funkcijas vienā, lai ir viss čiki briki
            return mylist.IndexOf(g);
        }
        public int LastIndexOf(Gramata g)
        {
            Console.WriteLine($"Pēdējā grāmata sarakstā ir: {mylist.Last().nosaukums}, {mylist.Last().autors}, {mylist.Last().lppSkaits}");
            Console.WriteLine($"Ar indeksu nr: {mylist.IndexOf(mylist.Last())}");
            return mylist.IndexOf(g);
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            MyList MyList = new MyList();
            bool stop = false;
            while (!stop)
            {
                Gramata g = new Gramata();

                Console.WriteLine("1 - Pievieno jaunu grāmatu");
                Console.WriteLine("2 - Izvada visas grāmatas uz ekrāna");
                Console.WriteLine("3 - Pievienot jaunu elementu index vietā");
                Console.WriteLine("4 - Norādīt elementu skaitu sarakstā");
                Console.WriteLine("5 - Izdzēst ar norādīto indeksu");
                Console.WriteLine("6 - Atrast elementu ar norādīto indeksu");
                Console.WriteLine("7 - Atrast un atgriezt pirmo sastapto elementu");
                Console.WriteLine("8 - Atrast un atgriezt pēdējo sastapto elementu");
                Console.WriteLine("9 - Iztīrīt sarakstu");
                Console.WriteLine("0 - Iziet no programmas");
                Console.Write("\nIzvēlies darbību: ");
                int darbiba = Convert.ToInt32(Console.ReadLine());
                switch (darbiba)
                {
                    case 0:
                        stop = true;
                        break;
                    case 1:
                        // Izveido jaunu objektu un pievieno to sarakstam. Listēs ir objekti. 
                        MyList.Add(g);
                        Console.WriteLine("Grāmata pievienota");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        // Izvada to, kas jau ir. 
                        MyList.Print();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Norādi indeksu: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        MyList.insert(index, g);
                        break;
                    case 4:
                        // Izsauc count fukciju no MyList klases, kur tiek skaitīti elementi no iekšējās listes.
                        Console.WriteLine($"Sarakstā ir {MyList.Count()} elementi");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("\nNorādi indeksu: ");
                        int del = Convert.ToInt32(Console.ReadLine());
                        MyList.RemoveAt(del);
                        break;
                    case 6:
                        Console.Clear();
                        Console.Write("\nIevadi indeksu, ar kuru vēlies meklēt elementu: ");
                        int mekindex = Convert.ToInt32(Console.ReadLine());
                        MyList.ElementAt(mekindex); 
                        break;
                    case 7:
                        MyList.FirstIndexOf(g);
                        break;
                    case 8:
                        MyList.LastIndexOf(g);
                        break;
                    case 9:
                        MyList.Clear();
                        break;
                    default:
                        Console.WriteLine("Tādu opciju nav");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
