using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4prak
{
    class Pietura
    {
        public int kartas_nr;
        public string nosaukums;
        public string laiks;
        public void Registret()
        {
            Console.Clear();
            Console.Write("\nIevadi pieturas kārtas numuru: ");
            kartas_nr = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nIevadi pieturas nosaukumu: ");
            nosaukums = Console.ReadLine();
            Console.WriteLine("\nIevadi pieturas laiku: ");
            laiks = Console.ReadLine();

            Console.WriteLine("Pietura reģistrēta");
            Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
            Console.ReadKey();
            Console.Clear();
        }
        public void Izvadit()
        {
            Console.WriteLine($"Pieturu kārtas numurs: {kartas_nr}");
            Console.WriteLine($"Pieturas nosaukums: {nosaukums}");
            Console.WriteLine($"Pieturas laiks: {laiks}");
        }
    }
    class Item
    {
        public Item NextItem;
        public Item PreviousItem;
        public Pietura pietura;
    }
    class MyList
    {
        public Item head;
        public void Add(Pietura p)
        {
            Item additem = new Item(); // Izveido jaunu saraksta elementu. 
            additem.pietura = p; // Piešķirt elementam grāmatu objektu.
            additem.NextItem = null; // Pēdējais pievienotais elements. Nākamajam pointerim jābūt null
            if (head == null)  // Ja ir tukšs, tad sāk ar pirmo elementu.
            {
                head = additem;
                additem.PreviousItem = null;
                return;
            }
            Item current = head;
            while (current.NextItem != null)
            {
                current = current.NextItem;
            }
            current.NextItem = additem;
            additem.PreviousItem = current;
        }
        public void PrintAZ()
        {
            int index = 0;
            if (head == null) // Pārbauda vai saraksts kautko vispār satur
            {
                Console.WriteLine("Saraksts ir tukšs!");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else
            {
                Item current = head;
                while (current != null) // Izciklē cauri sarakstam un izvada katru grāmatu līdz sasniedz beigas.
                {
                    Console.WriteLine("=================");
                    current.pietura.Izvadit();
                    Console.WriteLine($"Index: {index}");
                    current = current.NextItem;
                    index++;
                }
            }
        }
        public void PrintZA()
        {
            int index = 0;
            if (head == null)
            {
                Console.WriteLine("Saraksts ir tukšs!");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else
            {
                Item current = head;
                while (current.NextItem !=null)
                {
                    current = current.NextItem;
                    index++;
                }

                while (current != null)
                {
                    Console.WriteLine("=============");
                    current.pietura.Izvadit();
                    Console.WriteLine($"Index: {index}");
                    current = current.PreviousItem;
                    index--;
                }
            }
        }
        public void Insert(Pietura p, int index)
        {
            if (index < 0 || index > Count() + 1) // Pārbauda vai indekss ir derīgs. Pieskaitīts +1 lai ir pareizāks.
            {
                Console.WriteLine("Indekss ārpus robežām.");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                return;
            }

            Item insert = new Item();
            insert.pietura = p;
            Item pirms = head;
            if (index == 0 || head == null)
            {
                insert.NextItem = head;
                insert.PreviousItem = null; // Ja ir index 0 un galvenē nekas nebija, iepriekšējā elementa pointeris ir null.
                if (head != null)
                {
                    head.PreviousItem = insert;
                }
                head = insert;
                Console.WriteLine($"Pietura ierakstīta ar index {index}");
                return;
            }
            // Strādā OK. Tikai jāpārbauda ar elementiem kur iesprauž pa vidu.

            int currentindex = 0;
            while (currentindex < index - 1)
            {
                pirms = pirms.NextItem;
                currentindex++;
            }
            // Iespraušana sarakstā. Jāapstrādā, lai arī ir ar PreviousItem. Šis visu nogļuko.
            insert.NextItem = pirms.NextItem; // Elements pirms ievietošanas
            insert.PreviousItem = pirms; /// wowwww
            pirms.NextItem = insert; // Pievienotais elements tagad rāda uz ievietoto vērtību

            if (insert.NextItem != null)
            {
                // Ja iesprauž starp elementiem.
                insert.NextItem.PreviousItem = insert;
            }     

            Console.WriteLine($"Pietura pievienota ar index {index}");
            Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
            Console.ReadKey();
            Console.Clear();
        }
        public int Count()
        {

            int count = 0;
            int fail = -1; // Ja gadienā neizpildās, lai ir ko atgriezt. Bez void metodēm šo vajag, citādi čīkst.

            if (head == null)
            {
                Console.WriteLine("Saraksts ir tukšs.");
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
                return count; // Atgriež skaitu kas funkcionē kā indekss. Priekš grāmatu skaita, tur pieskaitīja klāt +1 lai ir salasāmāks.
            }
        }
        public void RemoveAt(int index)
        {

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
                if (head !=null) // Speciāls gadījums, ja gadienā mēģina izdzēst pēdējo atlikušo elementu sarakstā. Bez šī visulaiku meta Nullexception avāriju.
                {
                    head.PreviousItem = null; // Ja ir pirmais elements izdzēsts, previous item pointeris ir null.
                }
                Console.WriteLine($"Grāmata izdzēsta ar index {index}");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                return;
            }
            if (index == Count() - 1) // Ja ir 4 indeksi un 4 elementi, 4. elements uzreiz nederēs. Mistiskā kārtā, bez šī if statement, viņš manuāli neņem nost pēdējo elementu.
                                      // 4 elementi ar indeksiem: 0 1 2 3 
                                      // Šī funkcija nodrošina to, ka elements kas palika pēdējais pēc visu citu elementu izdzēšanas, lai programma neavarē, domājot ka indekss ir ārpus robežām, kaut tā nav.
            {
                pirms = head;
                while (pirms.NextItem.NextItem != null) // Ja aiznākamais elements nav null, aizvieto elementu ar izvēlēto indeksu ar iepriekšējo.
                {
                    pirms = pirms.NextItem;
                }
                pirms.NextItem = null; // Nākamais elements ir null, jeb atvieno pēdējo elementu no saraksta.
                return;

            }

            // Ciklē cauri tiklīdz sasniedz ievadīto indeksu. Kamēr nav, ciklē cauri elementiem tiklīdz ir.
            while (currentIndex < index - 1)
            {
                pirms = pirms.NextItem;
                currentIndex++; // Indeksē lai var atrast
            }

            // Definēts elements, tur saglabāts iepriekšējais elements.
            Item remove = pirms.NextItem;
            remove.PreviousItem = pirms;
            pirms.NextItem = remove.NextItem; // Aizvieto izdzēsto elementu ar elementu kas bija pirmstam.

            if (remove.NextItem != null)
            {
                // Noņem elementu..
                remove.NextItem.PreviousItem = pirms;
            }

            Console.WriteLine($"Pietura izdzēsta ar index {index}");
            Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
            Console.ReadKey();
        }
        public Pietura ElementAt(int index)
        {
            if (head == null)
            {
                Console.WriteLine("Saraksts ir tukšs.");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
            }
            if (index < 0 || index > Count() + 1)
            {
                Console.WriteLine("Index atrodas ārpus robežām");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
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
            if (index != null && read == null)
            {
                Console.WriteLine("Index atrodas ārpus robežām un/vai elements bija nesen dzēsts.");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Pietura ar index nr. {index} atrasta.");
                read.pietura.Izvadit();
            }
            return null; // Ja mēģina atgriezt grāmatu un tā atrodas ārpus robežām (kad read ir null), tā avarē. Ar null novērš to.
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
                Pietura p = new Pietura();
                Console.WriteLine("1 - Pievieno jaunu pieturu saraksta beigās");
                Console.WriteLine("2 - Izvadīt saturu (A - Z)");
                Console.WriteLine("3 - Izvadīt saturu (Z - A)");
                Console.WriteLine("4 - Pievieno jaunu pieturu ar index");
                Console.WriteLine("5 - Izvadīt saraksta elementu skaitu");
                Console.WriteLine("6 - Izņemt noteiktu pieturu ar index");
                Console.WriteLine("7 - Atrast noteikto pieturu ar index");
                Console.WriteLine("8 - Iztīrīt sarakstu");
                Console.WriteLine("9 - Beigt programmu");
                Console.Write("\nTava izvēle: ");
                string opcija = Console.ReadLine();

                int izvele;
                if (!int.TryParse(opcija, out izvele))
                {
                    Console.WriteLine("Nav ievadīts cipars!");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    switch (izvele)
                    {
                        case 1:
                            p.Registret();
                            myList.Add(p);
                            break;
                        case 2:
                            myList.PrintAZ();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            myList.PrintZA();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 4:
                            p.Registret();
                            Console.Write("Ievadi indeksu ar ko ievietot: ");
                            int index = Convert.ToInt32(Console.ReadLine());
                            myList.Insert(p, index);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 5:
                            if (myList == null || myList.head == null)
                            {
                                Console.WriteLine("Sarakstā nav elementu");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Pieturu skaits: {myList.Count()+1}\n");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 6:
                            if (myList == null || myList.head == null)
                            {
                                Console.WriteLine("Saraksts ir tukšs.");
                                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Write("Ievadi indeksu ar ko dzēst: "); // Pieņem indeksu, un nokonvertē lai ir stabili zināms, ka ir cipars.
                                int index1 = Convert.ToInt32(Console.ReadLine());
                                myList.RemoveAt(index1);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 7:
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
                                int index2 = Convert.ToInt32(Console.ReadLine());
                                myList.ElementAt(index2);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 8:
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
                        case 9:
                            stop = true;
                            break;
                        default:
                            Console.WriteLine("Tādas opcijas nav");
                            break;
                    }
                }
            }
        }
    }

}
