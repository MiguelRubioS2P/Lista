using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista
{
    class Program
    {

       //add,print,printall,done,reorder,quit

        static string line;
        static string command;
        static int indexSpace; //se necesita para usar el indexOf
        static List<string> list = new List<string>();
        static string chain;

        private static void Add(string chain)
        {
            Console.WriteLine();
            list.Add(chain);
            Console.WriteLine("Has been added");
        }

        private static void Print()
        {
            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}: " + list[i]);
                if (i == 2) break;
            }
            Console.WriteLine();
        }

        private static void PrintAll()
        {
            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}: " + list[i]);
            }
            Console.WriteLine();
        }

        private static void Done(string chain)
        {
            int n;
            Boolean number = int.TryParse(chain, out n);//miramos si se puede convertir en int el string
            Console.WriteLine("Soy number: " + number);
            Console.WriteLine("Soy n: " + n);
            Console.WriteLine("La lista tiene estos valores maximos: " + list.Count);
            if(number)
            {
                if(n <= list.Count)
                {
                    list.RemoveAt(n - 1);
                    Console.WriteLine("Has been removed, use PrintAll for watching the list");
                }
                else
                {
                    Console.WriteLine("Invalid number");
                }
            }
            else
            {
                Console.WriteLine("Not is number");
            }
        }

        private static void ReOrder(string chain)
        {
            //tengo que restar - 1 a los parametros
            string firstChain, secondChain,auxiliar,item;
            int firstWhite,firstP, secondP;
            //Console.WriteLine(chain);//viene con un espacio
            firstWhite = chain.IndexOf(' ');
            firstChain = chain.Substring(firstWhite + 1); //tenemos la cadena;
            firstWhite = firstChain.IndexOf(' ');
            auxiliar = firstChain.Substring(0, firstWhite);//primer parametro
            secondChain = firstChain.Substring(firstWhite + 1);
            //Console.WriteLine("primer parametro: " + auxiliar + " segundo parametro: " + secondChain);

            if(int.TryParse(auxiliar,out firstP) && int.TryParse(secondChain, out secondP)) {
                firstP = firstP - 1;
                secondP = secondP - 1;
                item = list[firstP];
                list.RemoveAt(firstP);
                list.Insert(secondP, item);
                Console.WriteLine("Use method printall for see the list");
            }
            else
            {
                Console.WriteLine("Not is a number");
            }
        }

        private static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Add <todo>");
            Console.WriteLine("Print");
            Console.WriteLine("PrintAll");
            Console.WriteLine("Done <todo number>");
            Console.WriteLine("ReOrder <item nr> <desired position>");
            Console.WriteLine("Quit");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {

            do
            {

                Menu();

                line = Console.ReadLine();


                try
                {
                    indexSpace = line.IndexOf(' ');//obtenemos el valor de posicion del primer espacio
                    command = line.Substring(0, indexSpace);//obtenemos el valor de la izquierda
                    chain = line.Substring(indexSpace);//obtenemos la cadena de la derecha

                }
                catch (IndexOutOfRangeException ex)
                {
                    command = line;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    command = line;
                }

                switch (command.ToLower())
                {
                    case "add":
                        Add(chain);
                        break;
                    case "print":
                        Print();
                        break;
                    case "printall":
                        PrintAll();
                        break;
                    case "done":
                        Done(chain);
                        break;
                    case "reorder":
                        ReOrder(chain);
                        Console.WriteLine("we are mainteance");
                        break;
                    case "quit":
                        break;
                    default:
                        Console.WriteLine("You have failed");
                        break;
                }

            } while (command != "quit");

        }

    }
}
