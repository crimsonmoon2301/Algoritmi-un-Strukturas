using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _3prakno0
{
    class Gramata
    {
        public string nosaukums;
        public string autors;
        public int lpp;
        
        public void Registret()
        {
            Console.Clear();
            Console.Write("\nIevadi grāmatu nosaukumu: ");
            nosaukums = Console.ReadLine();
            Console.Write("\nIevadi grāmatu autoru: ");
            autors = Console.ReadLine();
            Console.Write("\nIevadi grāmatu lapu skaitu: ");
            lpp = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Grāmata reģistrēta");
        }
        public void Izvadit()
        {
            Console.WriteLine($"Grāmatas nosaukums: {nosaukums}");
            Console.WriteLine($"Grāmatas autors: {autors}");
            Console.WriteLine($"Grāmatas lapu skaits: {lpp}");
        }
    }
    class Item
    {
        public Item NextItem;
        public Gramata gramata;
    }
    class MyList
    {
        public Item head;
        public void Add(Gramata g) {
            Item item = new Item(); // Izveido jaunu saraksta elementu. 
            item.gramata = g; // Piešķirt elementam grāmatu objektu.
            item.NextItem = null; 
            if (head == null)  // Ja ir tukšs, tad sāk ar pirmo elementu.
            {
                head = item;
                return;
            }
            Item current = head;
            while (current.NextItem != null)
            {
                current = current.NextItem;
            }
            current.NextItem = item;
        }
        public void Print() {
            if (head == null) // Pārbauda vai saraksts kautko vispār satur
            {
                Console.WriteLine("Saraksts ir tukšs!");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                return;
            }
            else
            {
                Item current = head;
                while (current != null) // Izciklē cauri sarakstam un izvada katru grāmatu līdz sasniedz beigas.
                {
                    Console.WriteLine("=================");
                    current.gramata.Izvadit();
                    current = current.NextItem;
                }
            }
        }
        public void Insert(Gramata g, int index)
        {
            if (index < 0 || index > Count() + 1) // Pārbauda vai indekss ir derīgs. Pieskaitīts +1 lai ir pareizāks.
            {
                Console.WriteLine("Indekss ārpus robežām.");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                return;
            }

            Item insert = new Item();
            insert.gramata = g;
            Item pirms = head;
            if (index == 0)
            {
                insert.NextItem = head;
                head = insert;
                Console.WriteLine($"Grāmata ierakstīta ar index {index}");
                return;
            }
            int currentindex = 0;
            while (currentindex < index - 1)
            {
                pirms = pirms.NextItem;
                currentindex++;
            }
            // Iespraušana sarakstā
            insert.NextItem = pirms.NextItem;
            pirms.NextItem = insert;
            Console.WriteLine($"Grāmata pievienota ar index {index}");
            Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
            Console.ReadKey();
        }

        public int Count() { 
                  
            int count = 0;
            int fail = -1; // Ja gadienā neizpildās, lai ir ko atgriezt. Bez void metodēm šo vajag, citādi čīkst.

            if (head == null)
            {
                Console.WriteLine("Saraksts ir tukšs");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                return fail;
            }
            else
            {
                Item current = head; // Sāk ar pirmo elementu, un tad indeksē kamēr sasniedz beigas.
                while (current.NextItem != null)
                {
                    count++;
                    current = current.NextItem;
                }
                return count; // Lai ir salasāmāk. Pievienojot pirmo grāmatu rāda 0, šis ir lai rāda 1
            }
        }
        public void RemoveAt(int index) {
        
            if (index < 0 || index >= Count()+1) // Pārbauda vai indekss ir derīgs. Pieskaitīts +1 lai ir pareizāks.
            {
                Console.WriteLine("Indekss ārpus robežām.");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                return;
            }

             Item pirms = head;
             int currentIndex = 0;

            if (index == 0)
            {
                head = head.NextItem;
                Console.WriteLine($"Grāmata izdzēsta ar index {index}");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                return;
            }
            if (index == Count() - 1)
            {
                pirms = head;
                while(pirms.NextItem.NextItem != null )
                {
                    pirms = pirms.NextItem;
                }
                pirms.NextItem = null;
                return;

            }

             while (currentIndex < index-1)
             {
                 pirms = pirms.NextItem;
                 currentIndex++;
             }
                
             Item remove = pirms.NextItem;
             pirms.NextItem = remove.NextItem;
             Console.WriteLine($"Grāmata izdzēsta ar index {index}");
             Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
             Console.ReadKey();
        }
      
        public Gramata ElementAt(int index) { return null; }
        public int FirstIndexOf(Gramata g)
        {
            int fail = -1; // Ja gadienā neizpildās, lai ir ko atgriezt.
            if (head == null) // Pārbauda vai sarakstā vispār ir kautkas.
            {
                Console.WriteLine("Saraksts ir tukšs");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                return fail;
            }
            Item current = head;
            int index = 0;
            Item lastItem = head;

            while (current != null)
            {
                // Salīdzina ar saraksta esošo informāciju ar objektu. Nav labākais veids, bet strādā tīri skaisti.
                if (current.gramata.nosaukums == g.nosaukums &&
                    current.gramata.autors == g.autors &&
                    current.gramata.lpp == g.lpp)
                {
                    Console.WriteLine("Pirmā atrastā grāmata sarakstā:");
                    current.gramata.Izvadit();
                    Console.WriteLine($"Ar indeksu: {index}");
                    return index; // atgriežam pirmo atrasto indeksu
                }

                current = current.NextItem;
                index++;
            }
            return index;
        }
        public int LastIndexOf(Gramata g)
        { 
            
            if (head == null)
            {
                Console.WriteLine("Saraksts ir tukšs.");
                Console.WriteLine("Piespied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                return -1;
            }
            Item current = head;
            int index = 0;
            int lastIndex = 0;
            Item lastItem = head;

            while (current != null)
            {
                lastItem = current;     // saglabā pašreizējo kā kandidātu
                lastIndex = index;      // saglabā tā indeksu
                current = current.NextItem;
                index++;
            }
            Console.WriteLine("Pēdējā grāmata sarakstā:");
            lastItem.gramata.Izvadit();
            Console.WriteLine($"Ar indeksu: {lastIndex}");

            return lastIndex;
        }
        public void Clear()
        { 
            // Iztīra sarakstu. head ir mūsu galvenais tikpat kā.
            head = null;
            Console.WriteLine("Saraksts iztīrīts");
            Console.ReadKey();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList myList = new MyList();
            bool stop = false;
            while (!stop)
            {
                Gramata g = new Gramata();
                Console.WriteLine("1 - Pievieno jaunu grāmatu");
                Console.WriteLine("2 - Izvadīt visas grāmatas");
                Console.WriteLine("3 - Pievieno jaunu grāmatu ar indeksu");
                Console.WriteLine("4 - Rādīt grāmatu skaitu");
                Console.WriteLine("5 - Dzēst grāmatu pēc indeksa");
                Console.WriteLine("6 - Atrast elementu");
                Console.WriteLine("7 - Parādīt pirmo atrasto grāmatu");
                Console.WriteLine("8 - Parādīt pēdējo atrasto grāmatu");
                Console.WriteLine("9 - Iztīrīt visu");
                Console.WriteLine("0 - Iziet no programmas");
                Console.Write("\nIevadi izvēli: ");
                int opcija = Convert.ToInt32(Console.ReadLine());
                switch (opcija)
                {
                    case 0:
                        stop = true; // Aptur programmu. Šis jau pašsaprotami.
                        break;
                    case 1:
                        g.Registret(); // Izsauc grāmatu reģistrēšanu, un pēctam pievieno sarakstam, padodot tālāk grāmata objektu.
                        myList.Add(g);
                        break;
                    case 2:
                        myList.Print();
                        Console.ReadKey();
                        break;
                    case 3:
                        g.Registret();
                        Console.Write("Ievadi indeksu ar ko ievietot: ");
                        int index2 = Convert.ToInt32(Console.ReadLine());
                        myList.Insert(g, index2); // varētu jau uzreiz readline iegāzt nevis atsevišķu mainīgo, bet nu labāk lai ir priekš manis pārskatāmāks.
                        break;
                    case 4:
                        Console.Write($"Grāmatu skaits: {myList.Count() +1}\n");
                        break;
                    case 5:
                        Console.Write("Ievadi indeksu ar ko dzēst: "); // Pieņem indeksu, un nokonvertē lai ir stabili zināms, ka ir cipars.
                        int index = Convert.ToInt32(Console.ReadLine());
                        myList.RemoveAt(index);
                        break;
                    case 6: // Vēl jāpilnveido.
                        Console.Write("Ievadi indeksu, kuru meklēt: ");
                        int index3 = Convert.ToInt32(Console.ReadLine());
                        myList.ElementAt(index3);
                        break;
                    case 7:
                        Console.WriteLine(myList.FirstIndexOf(myList.head.gramata)); // Paņem no saraksta pirmo grāmatu. Mocījos vairākas stundas šeit, vienkārši lai atjeģtos ka nav īstais objekts ņemts. man gribas raudāt.
                        break;
                    case 8:
                        Console.WriteLine(myList.LastIndexOf(myList.head.gramata)); // Līdzīgi kā ar case 7, tikai ar pēdējo elementu kas tika pievienots.
                        break;
                    case 9:
                        myList.Clear();
                        break;
                    default:
                        Console.WriteLine("Nepareiza izvēle!");
                        break;
                }
            }
        }
    }
}
