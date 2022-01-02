using System;

namespace Assignment14 {
    internal class Program {
        static void Main(string[] args) {
            // Choosing the currect structes
            Console.WriteLine("Please choose the desired structures:");
            Console.WriteLine("1. Sorted sets");
            Console.WriteLine("2. Unsorted sets");
            Console.WriteLine("3. Unsorted and disjoint sets");
            Console.Write("\nYour choice: ");
            int structureChoice = int.Parse(Console.ReadLine());

            switch (structureChoice) {
                case 1: { // Sorted
                        break;
                    }
                case 2: { // Unsorted
                        break;
                    }
                case 3: { // Disjoint
                        break;
                    }
                default: { // Invalid option
                        Console.WriteLine("Invalid option, re-launch the app and try again.");
                        break;
                    }
            }
        }
    }
}
