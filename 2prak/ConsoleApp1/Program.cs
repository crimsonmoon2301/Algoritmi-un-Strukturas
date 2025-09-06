using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Students
    {
        public string vards;
        public string uzvards;
    }
    internal class _2uzd
    {
        static ArrayList Melns = new ArrayList();
        static ArrayList Balts = new ArrayList();

        static bool stop = false;
        static bool atpakal= false;
        static void Main(string[] args)
        {
            
            while (!stop)
            {
                Console.WriteLine("Izvēlieties savu vēlamo darbību");
                Console.WriteLine("1 - Piepildīt Melno sarakstu");
                Console.WriteLine("2 - Piepildīt Balto sarakstu");
                Console.WriteLine("3 - Pārvietot ierakstus starp sarakstiem");
                Console.WriteLine("4 - Saglabāt sarakstus");
                Console.WriteLine("5 - Izdrukā sarakstus uz ekrāna");
                Console.WriteLine("6 - Iziet no programmas");

                Console.Write("\nTava izvēle: ");
                int izvele = Convert.ToInt32(Console.ReadLine());

                switch (izvele)
                {
                    case 1:
                        Console.WriteLine("Kuru studentu vēlies pievienot sarakstā?");
                        Console.Write("\nStudenta vārds: ");
                        string vards = Console.ReadLine();
                        Console.Write("\nStudenta uzvārds: ");
                        string uzvards = Console.ReadLine();

                        Students students = new Students();
                        students.vards = vards;
                        students.uzvards = uzvards;
                        Melns.Add(students);

                        Console.WriteLine("Studenti pievienoti melnajā sarakstā. Spied jebkuru pogu, lai turpinātu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Kuru studentu vēlies pievienot sarakstā?");
                        Console.Write("\nStudenta vārds: ");
                        string vards1 = Console.ReadLine();
                        Console.Write("\nStudenta uzvārds: ");
                        string uzvards1 = Console.ReadLine();

                        Students students1 = new Students();
                        students1.vards = vards1;
                        students1.uzvards = uzvards1;
                        Balts.Add(students1);

                        Console.WriteLine("Studenti pievienoti baltajā sarakstā. Spied jebkuru pogu, lai turpinātu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        if (Melns.Count == 0 && Balts.Count == 0)
                        {
                            Console.WriteLine("Saraksti ir tukši!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            ParvietoStudentu();
                        }
                        break;
                    case 4:
                        if (Balts.Count == 0 && Melns.Count == 0)
                        {
                            Console.WriteLine("Saraksti ir tukši.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            SaglabatSaraktus();
                        }
                        break;
                    case 5:
                        if (Melns.Count == 0 && Balts.Count == 0)
                        {
                            Console.WriteLine("Saraksti ir tukši!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Melnais saraksts:");
                            foreach (Students student in Melns)
                            {
                                Console.WriteLine($"{student.vards} {student.uzvards}");
                            }
                            Console.WriteLine("\nBaltais saraksts:");
                            foreach (Students student in Balts)
                            {
                                Console.WriteLine($"{student.vards} {student.uzvards}");
                            }
                        }
                        break;
                    case 6:
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("Tādu opciju nav!");
                        break;
                }
            }
        }
        static void SaglabatSaraktus()
        {
            while (!atpakal)
            {
                Console.Clear();
                Console.WriteLine("1 - Saglabāt un ierakstīt abus sarakstus failā");
                Console.WriteLine("2 - Nolasīt saglabāto sarakstu un izvadīt uz ekrāna");
                Console.WriteLine("3 - Atpakaļ uz galveno izvēlni");
                Console.Write("\nTava izvēle: ");
                int izvele = Convert.ToInt32(Console.ReadLine());
                switch (izvele)
                {
                    case 1:
                        if (Melns.Count == 0 && Balts.Count == 0)
                        {
                            Console.WriteLine("Saraksti ir tukši.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            using (StreamWriter sw = new StreamWriter("Saraksti.txt"))
                            {
                                sw.WriteLine($"Saraksts saglabāts {DateTime.Now}");
                                sw.WriteLine("====================================");
                                sw.WriteLine("Melnais saraksts:");
                                foreach (Students student in Melns)
                                {
                                    sw.WriteLine($"{student.vards} {student.uzvards}");
                                }
                                sw.WriteLine("\nBaltais saraksts:");
                                foreach (Students student in Balts)
                                {
                                    sw.WriteLine($"{student.vards} {student.uzvards}");
                                }
                                sw.WriteLine("====================================");
                            }
                            Console.WriteLine("Saraksti saglabāti failā Saraksti.txt. Spied jebkuru pogu, lai turpinātu.");
                            Console.ReadKey();
                            Console.Clear();
                        } 
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Saglabātais saraksts:");
                        if(!File.Exists("Saraksti.txt"))
                        {
                            Console.WriteLine("Fails neeksistē.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            using (StreamReader sr = new StreamReader("Saraksti.txt"))
                            {
                                string line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    Console.WriteLine(line);
                                }
                            }
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        atpakal = true;
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            }
        }
        static void ParvietoStudentu()
        {
            while (!atpakal)
            {
                Console.Clear();
                Console.WriteLine("1 - Pārvieto vienu studentu no Melnā saraksta uz Balto");
                Console.WriteLine("2 - Pārvieto vienu studentu no Baltā saraksta uz Melno");
                Console.WriteLine("3 - Pārvieto visus ierakstus no Melnā uz Baltā");
                Console.WriteLine("4 - Pārvieto visus ierakstus no Baltā uz Melnā");
                Console.WriteLine("5 - Apgriezt sarakstus otrādi (melns > balts, balts > melns)");
                Console.WriteLine("6 - Iziet atpakaļ uz galveno izvēlni");
                int izvele = Convert.ToInt32(Console.ReadLine());
                switch (izvele)
                {
                    case 1:
                        Console.WriteLine("Melnais saraksts: ");
                        foreach (Students melnstud in Melns)
                        {
                            Console.WriteLine($"{ melnstud.vards} { melnstud.uzvards}");
                        }
                        Console.WriteLine("Kurš students jāpārvieto?");

                        Console.WriteLine("Studenta vārds: ");
                        string vards = Console.ReadLine();
                        Console.WriteLine("Studenta uzvārds: ");
                        string uzvards = Console.ReadLine();

                        bool found = false;
                        foreach (Students melnstud in Melns)
                        {
                            if (melnstud.vards == vards && melnstud.uzvards == uzvards)
                            {
                                Balts.Add(melnstud);
                                Melns.Remove(melnstud);
                                found = true;
                                Console.WriteLine("Students pārvietots uz Balto sarakstu.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Students nav sarakstā.");
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Baltais saraksts: ");
                        foreach (Students baltstud in Balts)
                        {
                            Console.WriteLine($"{ baltstud.vards} { baltstud.uzvards}");
                        }
                        Console.WriteLine("Kurš students jāpārvieto?");
                        Console.WriteLine("Studenta vārds: ");
                        string vards1 = Console.ReadLine();
                        Console.WriteLine("Studenta uzvārds: ");
                        string uzvards1 = Console.ReadLine();
                        bool found1 = false;
                        foreach (Students baltstud in Balts)
                        {
                            if (baltstud.vards == vards1 && baltstud.uzvards == uzvards1)
                            {
                                Melns.Add(baltstud);
                                Balts.Remove(baltstud);
                                found1 = true;
                                Console.WriteLine("Students pārvietots uz Melno sarakstu.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Students nav sarakstā.");
                            }
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        if (Melns.Count == 0)
                        {
                            Console.WriteLine("Melnais saraksts ir tukšs.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            foreach (Students melnstud in Melns)
                            {
                                Balts.Add(melnstud);
                            }
                            Melns.Clear();
                            Console.WriteLine("Studenti pārvietoti no Melnā saraksta uz Balto.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 4:
                        if (Balts.Count == 0)
                        {
                            Console.WriteLine("Baltais saraksts ir tukšs.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            foreach (Students baltstud in Balts)
                            {
                                Melns.Add(baltstud);
                            }
                            Balts.Clear();
                            Console.WriteLine("Studenti pārvietoti no Baltā saraksta uz Melno");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 5:
                        ArrayList temp = new ArrayList(Melns);
                        Melns.Clear();
                        foreach (Students baltstud in Balts)
                        {
                            Melns.Add(baltstud);
                        }
                        Balts.Clear();
                        foreach (Students melnstud in temp)
                        {
                            Balts.Add(melnstud);
                        }
                        Console.WriteLine("Saraksti apgriezti.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        stop = true;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Tādu opciju nav.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
