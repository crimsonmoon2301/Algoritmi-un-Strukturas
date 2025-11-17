using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9prak
{
    class BTree
    {
        public BNode rootNode;

        public BTree()
        {
            rootNode = null;
        }
        
        public void Add(int n)
        {
            BNode newNode = new BNode(n);
            if (rootNode == null)
            {
                rootNode = newNode;
            }
            else
            {
                Add(n, rootNode);
            }

        }
        private void Add(int n, BNode ParentNode)
        {
            if (n < ParentNode.number)
            {
                if (ParentNode.leftNode == null)
                {
                    ParentNode.leftNode = new BNode(n);
                }
                else
                {
                    Add(n, ParentNode.leftNode);
                }
            }
            else
            {
                if (ParentNode.rightNode == null)
                {
                    ParentNode.rightNode = new BNode(n);
                }
                else
                {
                    Add(n, ParentNode.rightNode);
                }
            }
        }
        public void Print()
        {

        }
        private void Print(BNode N, string seperator)
        {

        }
        public int Remove(int number)
        {
            return 0;
        }
        public int FindNode(int n)
        {
            return 0;
        }
        public int Walk(BNode nod)
        {
            return 0;
        }


    }
    public class BNode
    {
        public int number;
        public BNode rightNode;
        public BNode leftNode;
        
        public BNode(int Number)
        {
            number = Number;
            leftNode = null;
            rightNode = null;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BTree koks = new BTree();
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("1 - Ievietot jaunu mezglu kokā");
                Console.WriteLine("2 - Izvada konkrēto mezglu");
                Console.WriteLine("3 - Izdzēst mezglu");
                Console.WriteLine("4 - Atrast mezglu");
                Console.WriteLine("5 - Rekursīvi apstaigā elementus");
                Console.WriteLine("0 - Beigt");

                Console.Write("\nTava izvēle: ");
                string opcija = Console.ReadLine();
                if (!int.TryParse(opcija, out int derigs))
                {
                    Console.WriteLine("Tev ir jānorāda cipars!");
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
                            koks.Add(20);
                            koks.Add(30);
                            koks.Add(50);
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        default:
                            Console.WriteLine("Tādas opcijas nav");
                            Console.ReadKey();
                            Console.Clear();
                        break;
                    }
                }
            }
        }
    }
}
