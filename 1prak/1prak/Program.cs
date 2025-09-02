using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1prak
{
    enum valsts
    {
       Latvija,
       Igaunija,
       Kina,
       ASV
    }
    class razotajs
    {
        public static string nosaukums { get; set; }
    }
    class sim_karte
    {
        public static string veids { get; set; }
        public static int tel_numurs { get; set; }
    }

    class tehnika
    {
        public static string krasa { get; set; }
    }
    class viedierice : tehnika
    {
        public static string operetajsistema { get; set; }
        public static double ekrana_izmers { get; set; }
        public static bool ir_hdmi { get; set; }
    }
    class mobilais_tel : viedierice
    {
        public static string modelis { get; set; }
        public static double svars { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int option;
            bool stop = false;
            Console.WriteLine("Sveicinati! Izvelies savu darbibu: ");

            while (!stop)
            {
                Console.WriteLine("\n1. - Izveidot mob_tel objektu kolekciju");
                Console.WriteLine("2. - Apskatit izveidoto kolekciju");
                Console.WriteLine("0 - Iziet no programmas\n");
                Console.Write("Tava izvele: ");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        stop = true;
                        Console.WriteLine("Darbiba partraukta");
                        break;
                    case 1:
                        kolekcijuIzveide();
                        break;
                    case 2:
                        if(File.Exists("telefonu_kolekcija.txt"))
                        {
                            string[] teksts = File.ReadAllLines("telefonu_kolekcija.txt");
                            foreach (string rindas in teksts)
                            {
                                Console.WriteLine(rindas);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Kolekciju nav.");
                        }
                            break;
                    default:
                        Console.WriteLine("Tadas opcijas seit nav.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        static void kolekcijuIzveide()
        {
            Console.Clear();
            Console.Write("Norādiet ražotāja nosaukumu: ");
            razotajs.nosaukums = Console.ReadLine();
            Console.Write("Pieejamas valstis: \n");
            foreach (valsts v in Enum.GetValues(typeof(valsts)))
            {
                Console.WriteLine(v);
            }
            Console.Write("Noradiet valsti: ");
            string valstsIzvele = Console.ReadLine();

            Console.Write("\nSim kartes veids: ");
            sim_karte.veids = Console.ReadLine();
            Console.Write("\nTelefona numurs: ");
            sim_karte.tel_numurs = int.Parse(Console.ReadLine());
            Console.Write("\nTelefona krasa: ");
            mobilais_tel.krasa = Console.ReadLine();
            Console.Write("\nOperetajsistema: ");
            mobilais_tel.operetajsistema = Console.ReadLine();
            Console.Write("\nEkrana izmers: ");
            mobilais_tel.ekrana_izmers = double.Parse(Console.ReadLine());
            Console.Write("\nIr HDMI (True/false): ");
            mobilais_tel.ir_hdmi = bool.Parse(Console.ReadLine());
            Console.Write("\nTelefona modelis: ");
            mobilais_tel.modelis = Console.ReadLine();
            Console.Write("\nTelefona svars (grami): ");
            mobilais_tel.svars = int.Parse(Console.ReadLine());

            // ierakstisana
            string filepath = "telefonu_kolekcija.txt";
            using (StreamWriter writer = new StreamWriter(filepath, true))
            {
                writer.WriteLine("---------------");
                writer.WriteLine($"Telefons ierakstits: {DateTime.Now}");
                writer.WriteLine("---------------");
                writer.WriteLine($"Ražotāja nosaukums:{razotajs.nosaukums}");
                writer.WriteLine($"Ražotāja valsts: {valstsIzvele}");
                writer.WriteLine($"SIM Kartes veids: {sim_karte.veids}");
                writer.WriteLine($"Telefona numurs: {sim_karte.tel_numurs}");
                writer.WriteLine($"Telefona krāsa: {mobilais_tel.krasa}");
                writer.WriteLine($"Telefona operetājsistēma: {mobilais_tel.operetajsistema}");
                writer.WriteLine($"Telefonu ekrānu izmērs: {mobilais_tel.ekrana_izmers}");
                writer.WriteLine($"HDMI pieejamība: {mobilais_tel.ir_hdmi}");
                writer.WriteLine($"Telefona modelis: {mobilais_tel.ir_hdmi}");
                writer.WriteLine($"Telefona svars: {mobilais_tel.svars}");
            }
            // Pabeigšana
            Console.WriteLine("Fails izveidots un ierakstīts. Varat to apskatīt izvelnē nospiežot 2.");
            Console.WriteLine("Nospiediet jebkuru pogu, lai beigtu.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
