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
            
            Item addItem = new Item(); // Izveido jaunu saraksta elementu. 
            addItem.gramata = g; // Piešķirt elementam grāmatu objektu.
            addItem.NextItem = null; // Pievieno saraskta beigās
            if (head == null)  // Ja ir tukšs, tad sāk ar pirmo elementu.
            {
                head = addItem;
                return;
            }
            Item current = head;
            while (current.NextItem != null) // Aiziet līdz beigām
            {
                current = current.NextItem;
            }
            current.NextItem = addItem; // Pievieno elementu
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
                int index = -1; // Lai nenokļūdos atrādīšanā
                while (current != null) // Izciklē cauri sarakstam un izvada katru grāmatu līdz sasniedz beigas.
                {
                    Console.WriteLine("=================");
                    current.gramata.Izvadit();
                    current = current.NextItem;
                    index++;
                    Console.WriteLine($"Index:{index} "); // Drošības pēc...
                }
            }
        }
        public void Insert(Gramata g, int index)
        {
            if (index < 0 || index > Count() +1 ) // Pārbauda vai indekss ir derīgs. Pieskaitīts +1 lai ir pareizāks.
            {
                Console.WriteLine("Indekss ārpus robežām.");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                return;
            }

            Item insert = new Item();
            insert.gramata = g;
            Item pirms = head;
            if (index == 0 || head == null)
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
            insert.NextItem = pirms.NextItem; // Elements pirms ievietošanas
            pirms.NextItem = insert; // Pievienotais elements tagad rāda uz ievietoto vērtību
            Console.WriteLine($"Grāmata pievienota ar index {index}");
            Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
            Console.ReadKey();
            Console.Clear();
        }

        public int Count() { 
                  
            int count = 0;
            int add = -1; // Ja gadienā neizpildās un vai notiek head==null situācija, lai ir ko atgriezt. Bez void metodēm šo vajag.

            // Izpildas tikai ja pievieno ar index pie tukšas sarakstes. Insert un RemoveAt šo izmanto lai nomērītu saraksta izmēru. Lielākoties Insert noder vairāk.
            if (head == null)
            {
                Console.WriteLine("Saraksts ir tukšs. Pievienojam...");
                return add;
            }
            else
            {
                Item current = head; // Sāk ar pirmo elementu, un tad indeksē kamēr sasniedz beigas.
                while (current.NextItem != null)
                {
                    count++;
                    current = current.NextItem;
                }
                return count; // Atgriež skaitu kas funkcionē kā indekss. Priekš grāmatu skaita, tur pieskaitīja klāt +1 lai ir salasāmāks.
            }
        }
        public void RemoveAt(int index) {
            
            if (index < 0 || index >= Count() + 1) // Pārbauda vai indekss ir derīgs. Pieskaitīts +1 lai ir pareizāks.
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
            // if (index == Count()-1)
            if (index == Count()) // Ja ir 4 indeksi un 4 elementi, 4. elements uzreiz nederēs. Mistiskā kārtā, bez šī if statement, viņš manuāli neņem nost pēdējo elementu.
                // 4 elementi ar indeksiem: 0 1 2 3 
                // Šī funkcija nodrošina to, ka elements kas palika pēdējais pēc visu citu elementu izdzēšanas, lai programma neavarē, domājot ka indekss ir ārpus robežām, kaut tā nav.
            {
                pirms = head;
                while(pirms.NextItem.NextItem != null ) // Ja aiznākamais elements nav null, aizvieto elementu ar izvēlēto indeksu ar iepriekšējo.
                {
                    pirms = pirms.NextItem;
                }
                pirms.NextItem = null; // Nākamais elements ir null, jeb atvieno pēdējo elementu no saraksta.
                Console.WriteLine($"Grāmata izdzēsta ar index {index}");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
                return;

            }

             // Ciklē cauri tiklīdz sasniedz ievadīto indeksu. Kamēr nav, ciklē cauri elementiem tiklīdz ir.
             while (currentIndex < index-1)
             {
                 pirms = pirms.NextItem;
                 currentIndex++; // Indeksē lai var atrast
             }
                
             // Definēts elements, tur saglabāts iepriekšējais elements.
             Item remove = pirms.NextItem;
             pirms.NextItem = remove.NextItem;
             Console.WriteLine($"Grāmata izdzēsta ar index {index}");
             Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
             Console.ReadKey();
        }
      
        public Gramata ElementAt(int index)
        {
            //if(head == null)
            //{
            //    Console.WriteLine("Saraksts ir tukšs.");
            //    Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
            //    Console.ReadKey();
            //}
            if(index < 0 || index > Count()+1)
            {
                Console.WriteLine("Index atrodas ārpus robežām");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                return null; // Varbūt nodzēs šo ja gadienā gļuko
            }
            Item read = head;
            int currentindex = 0;

            while (currentindex < index)
            {
                read = read.NextItem;
                currentindex++;
            }
            // Gadījās testējot, kad tiek izdzēsti vairāki elementi, ievada indeksu un garbage collector vēl nepaspēja noņemt. Der arī citām situācijām, bet nu labāk lai paliek.
            // Labāk es pārspīlēju ar ifiem, nekā pēctam rēķinos ar sekām, ka programma avarē atrādot.
            if(index != null && read == null)
            {
                Console.WriteLine("Index atrodas ārpus robežām un/vai elements bija nesen dzēsts.");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Grāmata ar index nr. {index} atrasta.");
                read.gramata.Izvadit();
            }
            return null; // Ja mēģina atgriezt grāmatu un tā atrodas ārpus robežām (kad read ir null), tā avarē. Ar null novērš to.
        }
        public int FirstIndexOf(Gramata g)
        {
            Item current = head;
            int currentIndex = 0;

            while (current != null)
            {
                if (current.gramata.nosaukums == g.nosaukums &&
                    current.gramata.autors == g.autors &&
                    current.gramata.lpp == g.lpp)
                {
                    Console.WriteLine($"Grāmata atrodas index {currentIndex}");
                    Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                    Console.ReadKey();
                    return currentIndex;
                }
                  
                current = current.NextItem;
                currentIndex++;
            }

            Console.WriteLine("Grāmata nav atrasta");
            Console.ReadKey();
            return -1;
            //int fail = -1; // Ja gadienā neizpildās, lai ir ko atgriezt.
            //if (head == null) // Pārbauda vai sarakstā vispār ir kautkas.
            //{
            //    Console.WriteLine("Saraksts ir tukšs");
            //    Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
            //    Console.ReadKey();
            //    return fail;
            //}
            //Item current = head;
            //int index = 0;

            //while (current != null)
            //{
            //    // Salīdzina ar saraksta esošo informāciju ar objektu. Nav labākais veids, bet strādā tīri skaisti. Ja sakrīt, izsauc grāmatu klases izvadīšanas funkciju un paņem tagadējo elementu kā referenci.
            //    if (current.gramata.nosaukums == g.nosaukums &&
            //        current.gramata.autors == g.autors &&
            //        current.gramata.lpp == g.lpp)
            //    {
            //        Console.WriteLine("Pirmā atrastā grāmata sarakstā:");
            //        current.gramata.Izvadit();
            //        Console.Write($"\nAr indeksu: ");
            //        return index; // atgriežam pirmo atrasto indeksu
            //    }

            //    current = current.NextItem;
            //    index++;
            //}
            //if (current == null)
            //{
            //    Console.WriteLine("Saraksts nesen tika iztīrīts. Darbība apturēta.");
            //    Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
            //    return fail;
            //}
            //return index;
        }
        public int LastIndexOf(Gramata g)
        {
            if (head == null)
            {
                Console.WriteLine("Saraksts ir tukšs.");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                return -1;
            }

            Item current = head;
            int index = 0;
            int lastIndex = -1;

            while (current != null)
            {
                if (current.gramata.nosaukums == g.nosaukums &&
                    current.gramata.autors == g.autors &&
                    current.gramata.lpp == g.lpp)
                {
                    lastIndex = index;
                }

                current = current.NextItem;
                index++;
            }

            if (lastIndex != -1)
            {
                Console.Write($"\nGrāmata atrodas pēdējā reizē pie index ");
                return lastIndex;

            }
            else
            {
                Console.WriteLine("Grāmata nav atrasta");
                return -1;
            }
        }
        //public int LastIndexOf(Gramata g)
        //{
        //    int fail = -1; // Ja gadienā neizpildās, lai ir ko atgriezt.
        //    if (head == null) // Pārbauda vai sarakstā vispār ir kautkas.
        //    {
        //        Console.WriteLine("Saraksts ir tukšs");
        //        Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
        //        Console.ReadKey();
        //        return fail;
        //    }
        //    Item current = head;
        //    int index = 0;
        //    int currentindex = 0;

        //    // Salīdzina ar saraksta esošo informāciju ar objektu. Nav labākais veids, bet strādā tīri skaisti. Ja sakrīt, izsauc grāmatu klases izvadīšanas funkciju un paņem tagadējo elementu kā referenci.

        //    while (current.NextItem !=null)
        //    {
        //        current = current.NextItem; // Ciklē cauri elementiem
        //        // Ja sakrīt nosaukumi, saglabā to
        //        if (current.gramata.nosaukums == g.nosaukums &&
        //        current.gramata.autors == g.autors &&
        //        current.gramata.lpp == g.lpp)
        //        {
        //            currentindex = index; // Saglabā indeksu priekš cikla
        //        }
        //        else
        //        {
        //            index++; // Inkrementē pašu index
        //        }
        //    }

        //    // Extra gadījums. Atgadījās testēšanā
        //    if (current == null)
        //    {
        //        Console.WriteLine("Saraksts nesen tika iztīrīts. Darbība apturēta.");
        //        Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
        //        return fail;
        //    }

        //    // Ja neatgrieza -1, izvada pēdējo sastapto elementu no indeksa. 
        //    if (currentindex != fail)
        //    {
        //        Console.WriteLine("Pēdējā grāmata sarakstā:");
        //        for (int i = 0; i < currentindex; i++)
        //        {
        //            current = current.NextItem;
        //        }
        //        current.gramata.Izvadit();
        //        Console.Write("\nAr index: ");
        //    }
        //    return index;

        //    //if (g == null)
        //    //{
        //    //    Console.WriteLine("Saraksts ir tukšs.");
        //    //    Console.WriteLine("Piespied jebkuru pogu, lai turpinātu");
        //    //    Console.ReadKey();
        //    //    return -1;
        //    //}
        //    //Item current = head;
        //    //int index = 0;
        //    //int lastIndex = 0;
        //    //Item lastItem = head;

        //    //while (current != null)
        //    //{
        //    //    lastItem = current; // Ievieto pēdējo elementu atsevišķā mainīgajā    
        //    //    lastIndex = index;      // saglabā tā indeksu
        //    //    current = current.NextItem;
        //    //    index++;
        //    //}
        //    //Console.WriteLine("Pēdējā grāmata sarakstā:");
        //    //lastItem.gramata.Izvadit();
        //    //Console.Write($"\nAr indeksu: ");
        //    //return lastIndex;

        //}
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
                string opcija = Console.ReadLine();

                int izveletais;

                bool derigs = int.TryParse(opcija, out izveletais);

                if (!derigs)
                {
                    Console.WriteLine("\nIevadi ciparu! Viss ir ok :)");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    switch (izveletais)
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
                            Console.Clear();
                            break;
                        case 3:
                            g.Registret();
                            Console.Write("Ievadi indeksu ar ko ievietot: ");
                            int index2 = Convert.ToInt32(Console.ReadLine());
                            myList.Insert(g, index2); // varētu jau uzreiz readline iegāzt nevis atsevišķu mainīgo, bet nu labāk lai ir priekš manis pārskatāmāks.
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 4:
                            if (myList.head == null)
                            {
                                Console.WriteLine("Sarakstā nav grāmatu");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Write($"Grāmatu skaits: {myList.Count() + 1}\n");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 5:
                            if (myList == null || myList.head == null)
                            {
                                Console.WriteLine("Saraksts ir tukšs!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Write("Ievadi indeksu ar ko dzēst: "); // Pieņem indeksu, un nokonvertē lai ir stabili zināms, ka ir cipars.
                                int index = Convert.ToInt32(Console.ReadLine());
                                myList.RemoveAt(index);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 6: // Strādā tīri ok. Tikai jāpievaktē dziļākā testēšanā.
                            if (myList == null || myList.head == null)
                            {
                                Console.WriteLine("Saraksts ir tukšs");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Write("Ievadi indeksu, kuru meklēt: ");
                                int index3 = Convert.ToInt32(Console.ReadLine());
                                myList.ElementAt(index3);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 7:
                            // Foršs veids kā apiet nullexception, ja liste nav inicializēta pirms palaiž šo funkciju.
                            if (myList == null || myList.head == null)
                            {
                                Console.WriteLine("Saraksts ir tukšs.");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                g.Registret();
                                Console.WriteLine(myList.FirstIndexOf(g)); // Paņem no saraksta pirmo grāmatu. Mocījos vairākas stundas šeit, vienkārši lai atjeģtos ka nav īstais objekts ņemts. man gribas raudāt.
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 8:

                            // Foršs veids kā apiet nullexception, ja liste nav inicializēta pirms palaiž šo funkciju.
                            if (myList == null || myList.head == null)
                            {
                                Console.WriteLine("Saraksts ir tukšs.");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                g.Registret();
                                Console.WriteLine(myList.LastIndexOf(g)); // Līdzīgi kā ar case 7, tikai ar pēdējo elementu kas tika pievienots.
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 9:
                            if (myList == null || myList.head == null)
                            {
                                Console.WriteLine("Sarakstā nav ko tīrīt.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                myList.Clear();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        default:
                            Console.WriteLine("Nepareiza izvēle!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }
        }
    }
}