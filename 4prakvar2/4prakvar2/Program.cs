using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4prakvar2
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
        public Item Next;
        public Item Prev;
        public Pietura Data;

        // Nodefinēti datu mezgli ar saviem pointeriem.
        public Item(Pietura data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }

    }
    class MyList
    {
        // Nodefinēti listes galvene un aste
        public Item head;
        public Item tail;

        // Izveido tukšu listi
        public MyList()
        {
            head = null;
            tail = null;
        }

        public void Add(Pietura p)
        {
            // Ja nav iepriekšējie elementi, pievieno tos pie galvenes un astes.
            Item addItem = new Item(p);
            if (head == null)
            {
                head = tail = addItem;
            }
            else // Ja ir, tad pievieno to pie beigām.
            {
                tail.Next = addItem;
                addItem.Prev = tail;
                tail = addItem; // Pievieno jauno elementu saraksta beigās
            }
        }
        public void PrintAZ()
        {
            if (head == null)
            {
                Console.WriteLine("Saraksts ir tukšs");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else
            {
                // Ņem referenci no galvenes un iet līdz beigām tiklīdz sasniedz null
                Item current = head;
                int index = 0;
                while (current != null)
                {
                    Console.WriteLine("=================");
                    current.Data.Izvadit(); // Izvada datus par katru mezglu
                    Console.WriteLine($"Index: {index}");
                    current = current.Next; // Iet cauri sarakstam tiklīdz null
                    index++;
                }
            }
        }
        public void PrintZA()
        {
            if (tail == null)
            {
                Console.WriteLine("Saraksts ir tukšs");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            else
            {
                // Ņem referenci no astes, lai var sākt iet uz atpakaļ.
                Item current = tail;
                int index = Count(); // Izmanto count lai var zināt sākotnējo indeksu. Tā, lai ir vieglāk saprast vai strādā apgriezšana.
                while (current != null)
                {
                    Console.WriteLine("=================");
                    current.Data.Izvadit(); // Izvada datus par katru mezglu
                    Console.WriteLine($"Index: {index}");
                    current = current.Prev; // Iet atpakaļgaitā cauri sarakstam tiklīdz null
                    index--;
                }
            }
        }
        public void Insert(Pietura p, int index)
        {
            if (index < 0 || index > Count()) // Pārbauda vai indekss ir derīgs. Nevaru pieskaitīt, citādi ZA sāk brukt.
            {
                Console.WriteLine("Indekss ārpus robežām.");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                return;
            }

            // Izveido jaunu item un piešķir tai datus.
            Item insertItem = new Item(p);
            insertItem.Data = p;

            // Ievietošana sākumā
            if (index == 0)
            {
                // Jaunais norāda uz iepriekšējo
                insertItem.Next = head;
                if (head != null)
                {
                    head.Prev = insertItem; // Ja nav null, piesaista iepriekšējo
                }
                head = insertItem; // Pārbīda sākummu
                if (tail == null) // Ja tukšs, jaunais kļūst par pēdējo pievienoto
                {
                    tail = insertItem;
                }
                Console.WriteLine($"Pietura pievienota ar index {index}");
                return;
            }
            // Ievietošana beigās
            if (index == Count())
            {
                tail.Next = insertItem; // Vecais elements norāda uz jauno
                insertItem.Prev = tail; // Jaunais norāda atpakaļ uz veco
                tail = insertItem; // Pievieno jauno elementu saraksta beigās
                Console.WriteLine($"Pietura pievienota ar index {index}");
                return;
            }
            // Ievieto pa vidu
            Item pirms = head;
            int currentindex = 0;

            // Atrod elementu pirms ievietotā. Droši vien varēja ar prev kautko, bet šis strādā labi.
            while (currentindex < index - 1)
            {
                pirms = pirms.Next;
                currentindex++;
            }

            // Aizvieto elementus.
            insertItem.Next = pirms.Next; // Pievienotais elements tagad ir tagadējais
            insertItem.Prev = pirms; // iepriekšējais elements pirms ievietotā
            pirms.Next = insertItem; // Aizvieto aiz iepriekšējā elementa jauno elementu

            // Pievieno, jeb "piesprauž" elementu starp diviem elementiem, ja tādu ir.
            if (insertItem.Next != null)
            {
                // Next.Prev = starp nākamo un iepriekšējo elementu
                insertItem.Next.Prev = insertItem;
            }
            Console.WriteLine($"Pietura pievienota ar index {index}");
            Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
        }
        public void Clear()
        {
            // Iztīra gan galveni, gan kājeni/asti.
            head = tail = null;
            Console.WriteLine("Saraksts iztīrīts");
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count()) // Pārbauda vai indekss ir derīgs. Pieskaitīt nevaru, citādi printZA nestrādā kā vajag.
            {
                Console.WriteLine("Indekss ārpus robežām.");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
                return;
            }

            // No sākuma dzēšot
            if (index == 0)
            {
                head = head.Next;
                if (head != null)
                {
                    head.Prev = null; // Noņem saiti ar iepriekšējo, ja ir
                }
                else
                {
                    tail = null; // Iztukšo sarakstu ja ir pēdējā
                }

                Console.WriteLine($"Pietura izdzēsta ar index {index}");
                return;
            }

            // Ja indekss ir vienāds ar elementu skaitu. Speciāls gadījums
            if (index == Count())
            {
                tail = tail.Prev;
                if (tail != null)
                {
                    tail.Next = null; // Ja gadienā ir vairāki elementi un vēlas noņemt pie beigām.
                }
                else
                {
                    head = null; // Ja palika tikai viens elements sarakstā
                }
                Console.WriteLine($"Pietura izdzēsta ar index {index}");
                return;
            }
            Item pirms = head;
            int currentIndex = 0;
            while (currentIndex < index - 1)
            {
                pirms = pirms.Next;
                currentIndex++;
            }

            Item remove = pirms.Next;
            pirms.Next = remove.Next;
            // Izdzēšot elementu kura ir iesprausta starp diviem.
            if (remove.Next != null)
            {
                remove.Next.Prev = pirms;
            }

            Console.WriteLine($"Pietura izdzēsta ar index {index}");
            Console.WriteLine("Spied jebkuru pogu, lai turpinātu.");
        }
        public Pietura ElementAt(int index)
        {
            if (head == null)
            {
                Console.WriteLine("Saraksts ir tukšs.");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
            }
            if (index < 0 || index > Count())
            {
                Console.WriteLine("Index atrodas ārpus robežām");
                Console.WriteLine("Spied jebkuru pogu, lai turpinātu");
                Console.ReadKey();
            }
            Item read = head;
            int currentindex = 0;

            while (currentindex < index)
            {
                read = read.Next;
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
                read.Data.Izvadit();
            }
            return null; // Ja mēģina atgriezt pieturu un tā atrodas ārpus robežām (kad read ir null), tā avarē. Ar null novērš to.
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
                while (current.Next != null)
                {
                    count++;
                    current = current.Next;
                }
                return count; // Atgriež skaitu kas funkcionē kā indekss. Priekš pieturu skaita, tur pieskaitīja klāt +1 lai ir salasāmāks.
            }
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
                                Console.WriteLine($"Pieturu skaits: {myList.Count() + 1}\n");
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
