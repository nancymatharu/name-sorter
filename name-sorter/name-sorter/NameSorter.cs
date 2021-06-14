//Name-Sorter Program
// Program to sort alphabetically last names, then by any given names and print to file 'sorted-names.txt'

using System;
using System.IO;
using System.Linq;

namespace name_sorter
{
    class NameSorter
    {
        public static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                //Check if file passed in command line exists
                if (File.Exists(args[0]))
                {
                    //sort names using Linq OrderBy() & ThenBy method
                    var lastNames = File.ReadAllLines(args[0]).OrderBy(line => line.Split(' ').Last()).ThenBy(line => line.Split(' ').Reverse().Take(2).Last());

                    //writing sorted names on console
                    foreach (var name in lastNames)
                    {
                        Console.WriteLine(name);
                    }

                    //creating the path to create sorted text file 
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "sorted.txt");

                    //writing the sorted names in a file at path 
                    File.WriteAllLines(path, lastNames);

                    Console.WriteLine("\nSorted list of names are stored in sorted.txt at " + path);
                    Console.ReadKey();
                }
            }
            //if args passed is null
            else
            {
                Console.WriteLine("no arguments were passed, please pass unsorted-name.txt during execution");
                Console.ReadKey();
            }
        }
    }
}