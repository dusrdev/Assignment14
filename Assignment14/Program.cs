using System;

using Assignment14.Structures;
using Assignment14.Helpers;

namespace Assignment14 {
    internal class Program {
        static void Main(string[] args) {
            // Gotta sign my own code, right?
            Console.WriteLine("Author --> David Shnayder (id: 207054818)");
            Console.WriteLine();

            // Choosing the currect structes
            Console.WriteLine("Please choose the desired structures:");
            Console.WriteLine("1. Sorted sets");
            Console.WriteLine("2. Unsorted sets");
            Console.WriteLine("3. Unsorted and disjoint sets");
            Console.Write("\nYour choice: ");
            int structureChoice = int.Parse(Console.ReadLine());

            MergeableHeaps db = null; // create the reference for selected structure type

            switch (structureChoice) {
                case 1: { // Sorted
                        db = new Sorted();
                        break;
                    }
                case 2: { // Unsorted
                        db = new Unsorted();
                        break;
                    }
                case 3: { // Disjoint
                        db = new Disjoint();
                        break;
                    }
                default: { // Invalid option
                        Console.WriteLine("Invalid option, re-launch the app and try again.");
                        return;
                    }
            }

            CommandExecuter executer = new CommandExecuter(db); // Initialize executer

            // Choice of inout method

            Console.WriteLine();
            Console.WriteLine("Please choose the input method:");
            Console.WriteLine("1. Commandline");
            Console.WriteLine("2. Text file");
            Console.Write("\nYour choice: ");
            int inputMethod = int.Parse(Console.ReadLine());

            switch (inputMethod) {
                case 1: { // Command line input
                        bool stopRequested = false; // Allows the user to stop inputing
                        Console.WriteLine();
                        Console.WriteLine("Enter your commands, empty command will stop the app");
                        Console.WriteLine();
                        while (!stopRequested) {
                            Console.Write("--> ");
                            string command = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(command)) { // If input is empty, end input
                                stopRequested = true;
                            } else {
                                executer.ExecuteCommand(command);
                            }
                        }
                        break;
                    }
                case 2: { // Using a text file
                        Console.WriteLine();
                        Console.WriteLine("Put the text file named \"commands.txt\" the executable folder and press anykey to continue.");
                        Console.ReadKey();
                        Console.WriteLine();
                        string[] commands;
                        Parser p = new Parser();
                        if (!p.ReadCommandsFromFile(out commands)) { // Parsing failed
                            Console.WriteLine("Reading from file failed or contained no commands, try again.");
                        } else {
                            foreach (string command in commands) { // Parsing succeeded, execute.
                                Console.WriteLine($"--> {command}");
                                executer.ExecuteCommand(command);
                            }
                        }
                        break;
                    }
                default: { // Invalid option
                        Console.WriteLine("Invalid option, re-launch the app and try again.");
                        return;
                    }
            }

            Console.WriteLine("Press any key to continue"); // Keeps the program open to show the user the final output
            Console.ReadKey();
        }
    }
}
