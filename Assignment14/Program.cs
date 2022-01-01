using System;

namespace Assignment14 {
    internal class Program {
        static void Main(string[] args) {
            // Choosing the currect structes
            Console.WriteLine("Please choose the desired structures:");
            Console.WriteLine("1. Sorted lists");
            Console.WriteLine("2. Unsorted lists");
            Console.WriteLine("3. Estranged lists");
            Console.Write("\nYour choice: ");
            int structureChoice = int.Parse(Console.ReadLine());

            switch (structureChoice) {
                case 1: { // Sorted
                        break;
                    }
                case 2: { // Unsorted
                        break;
                    }
                case 3: { // Estranged
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
