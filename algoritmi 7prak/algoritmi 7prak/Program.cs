using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace algoritmi_7prak
{
    internal class Program
    {
        static Random rand = new Random();
        static int operacijasBubble = 0;
        static int operacijasInsert = 0;
        static string csv = "rezultati.csv";
        static void Main(string[] args)
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("1 - Sākt algoritmu kārtošanas darbības");
                Console.WriteLine("2 - Apskatīt CSV");
                Console.WriteLine("3 - Iztīrīt CSV");
                Console.WriteLine("4 - Beigt");
                Console.Write("\nTava izvēle: ");
                string izvele = Console.ReadLine();
                if (!int.TryParse(izvele, out int derigs))
                {
                    Console.WriteLine("Ievadi ciparu");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    switch (derigs)
                    {
                        case 1:
                            Console.WriteLine("Šis var aizdot kādu laiku. Lūdzu uzgaidīt...");
                            Sagatavosana_uzpilde();
                            break;
                        case 2:
                            if (File.Exists(csv))
                            {
                                string saturs = File.ReadAllText(csv);
                                if (string.IsNullOrWhiteSpace(saturs))
                                {
                                    Console.WriteLine("Fails ir tukšs. Iespējams tika iztīrīts manuāli.");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine(saturs);
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Fails neeksistē. Palaid algoritmus");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 3:
                            if (File.Exists(csv))
                            {
                                File.Delete(csv);
                                Console.WriteLine("CSV fails izdzēsts");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("CSV fails neeksistē");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 4:
                            stop = true;
                            break;
                        default:
                            Console.WriteLine("Tāda opcija šeit nav");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }
        }
        static void Sagatavosana_uzpilde()
        {
            if (!File.Exists(csv))
            {
                using (StreamWriter writer = new StreamWriter(csv))
                {
                    writer.WriteLine($"# CSV pirmo reizi izveidots: {DateTime.Now}");
                }
            }
            using (StreamWriter sw = new StreamWriter(csv))
            {
                sw.WriteLine("Izmers,tips,Algoritms,Operacijas");
                // Pārsūta uz masīvu izveidi
               
                for (int n = 100; n <= 10000; n += 100)
                {
                    // Nodefinē masīvu veidus
                    string[] veidi = { "Augosa", "Dilst", "Gadijuma", "Unique", "GandrizAug", "GandrizDilst" };

                    foreach (string veids in veidi)
                    {
                        int[] mass = MasivuIzveide(n, veids);

                        int[] masscopy = (int[])mass.Clone();
                        operacijasBubble = 0;
                        bubbleSort(masscopy, n);
                        sw.WriteLine($"{n},{veids},BubbleSort,{operacijasBubble}");
                    }
                    
                    foreach (string veids in veidi)
                    {
                        int[] mass = MasivuIzveide(n, veids);

                        int[] masscopy = (int[])mass.Clone();
                        operacijasInsert = 0;
                        insertionSort(masscopy);
                        sw.WriteLine($"{n},{veids},InsertionSort,{operacijasInsert}");
                    }
                    sw.WriteLine("==========");
                }
            }
            //printArray(mass, n);

            Console.WriteLine($"Rezultāti saglabāti {csv}");
        }
        static int[] MasivuIzveide(int n, string veids)
        {
            int[] arr = new int[n];
            switch (veids)
            {
                case "Augosa":
                    for (int i = 0; i < n; i++)
                    {
                        arr[i] = i;
                    }
                    //printArray(arr,n);
                    break;
                case "Dilst":
                    for (int i = 0; i < n; i++)
                    {
                        arr[i] = i;
                    }
                    Array.Reverse(arr);
                    break;
                case "Gadijuma":
                    for (int i = 0; i < n; i++)
                    {
                        arr[i] = rand.Next(0, n);
                    }
                    break;
                case "Unique": // es hvz ko te likt. Met ārpus robežām.
                    for (int i = 0; i < n; i++)
                    {
                        arr[i] = rand.Next(0, n);
                        bool isDuplicate = false;
                        for (int j = 0; j < i; j++)
                        {
                            if (arr[i] == arr[j])
                            {
                                isDuplicate = true;
                            }
                        }
                        if (!isDuplicate)
                        {
                            arr[i] = i;
                        }
                    }
                    //List<int> navunique = new List<int>(arr);
                    //for (int i = 0; i < arr.Length-1; i++)
                    //{
                    //    navunique.Add(rand.Next(0,n));
                    //    //arr[] = navunique[].Distinct().ToArray();
                    //}
                    //arr = navunique.Distinct().ToArray();
                    break;
                case "GandrizAug":
                    break;
                case "GandrizDilst":
                    break;
                default:
                    Console.WriteLine("Kautkas aizgāja greizi");
                    break;
            }
            return arr;
        }
        static void bubbleSort(int[] arr, int n)
        {
            int i, j, temp;
            bool swapped;
            for (i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {

                        // Swap arr[j] and arr[j+1]
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }
                // If no two elements were
                // swapped by inner loop, then break
                if (swapped == false)
                    break;
                operacijasBubble++;
            }
        }

        private static void Quick_Sort(int[] arr, int left, int right)
        {
            // Check if there are elements to sort
            if (left < right)
            {
                // Find the pivot index
                int pivot = Partition(arr, left, right);

                // Recursively sort elements on the left and right of the pivot
                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }
        }

        // Method to partition the array
        private static int Partition(int[] arr, int left, int right)
        {
            // Select the pivot element
            int pivot = arr[left];

            // Continue until left and right pointers meet
            while (true)
            {
                // Move left pointer until a value greater than or equal to pivot is found
                while (arr[left] < pivot)
                {
                    left++;
                }

                // Move right pointer until a value less than or equal to pivot is found
                while (arr[right] > pivot)
                {
                    right--;
                }

                // If left pointer is still smaller than right pointer, swap elements
                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    // Return the right pointer indicating the partitioning position
                    return right;
                }
            }
        }
        static void insertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                /* Move elements of arr[0..i-1], that are
                   greater than key, to one position ahead
                   of their current position */
                while (j >= 0 && arr[j] > key)
                {
                    operacijasInsert++;
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
                
            }
        }
        static void printArrayInsert(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");

            Console.WriteLine();
        }
        static void printArray(int[] arr, int size)
        {
            int i;
            for (i = 0; i < size; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
