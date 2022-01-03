using System;

using Assignment14.Structures;

namespace Assignment14.Helpers {
    /// <summary>
    /// This class takes commands from user and executes them on the selected data structure type
    /// <para>
    /// Since multiple instances of the strucure can be created by the user, it saves the last 2 created.
    /// </para>
    /// <para>
    /// If a 3rd is created the first becomes the second and second is recreated and becomes the active one.
    /// </para>
    /// <para>
    /// When union is used, the second is merged into the first and gets deleted, the merged set (first) becomes the active set
    /// </para>
    /// </summary>
    internal class CommandExecuter {
        private MergeableHeaps DB1;
        private MergeableHeaps DB2;
        private MergeableHeaps ActiveDB;

        public CommandExecuter(MergeableHeaps db) {
            DB1 = db;
            ActiveDB = DB1;
        }

        /// <summary>
        /// Sets the first database as active
        /// </summary>
        private void SetDB1AsActive() {
            ActiveDB = DB1;
        }

        /// <summary>
        /// Resets the second database and sets it as the active
        /// </summary>
        private void SetDB2AsActive() {
            if (DB2 is null) {
                if (DB1 is Sorted) {
                    DB2 = new Sorted();
                } else if (DB1 is Unsorted) {
                    DB2 = new Unsorted();
                } else if (DB1 is Disjoint) {
                    DB2 = new Disjoint();
                }
                ActiveDB = DB2;
            }
        }

        /// <summary>
        /// Executes the user command
        /// </summary>
        /// <param name="command"></param>
        public void ExecuteCommand(string command) {
            string[] parts = command.Split(); // Split the command to parts

            // Allows better structure to view 1 word vs 2 word commands
            switch (parts.Length) {
                case 1: { // One word commands
                        if (parts[0] == "ExtractMin") {
                            int value = ActiveDB.ExtractMin();
                            Console.WriteLine($"Min extracted, min = {value}");
                            Console.WriteLine(ActiveDB.ToString());
                        } else if (parts[0] == "Minimum") {
                            Console.WriteLine($"Min = {ActiveDB.Minimum()}");
                        } else if (parts[0] == "Union") {
                            if (ActiveDB is null || ActiveDB.IsEmpty()) { // Last active is still empty
                                Console.WriteLine("Nothing to merge yet.");
                            } else if (DB2 is null || DB2.IsEmpty()) { // No items in new heap
                                Console.WriteLine("There is only one heap.");
                            } else { // Both have items. explanation on what happens is in class summary
                                DB1.Union(DB2);
                                DB2 = null;
                                SetDB1AsActive();
                                Console.WriteLine("Heaps were merged");
                                Console.WriteLine(ActiveDB.ToString());
                            }
                        } else if (parts[0] == "MakeHeap") {
                            if (ActiveDB is null || ActiveDB.IsEmpty()) { // If the active is empty no need to create a new one
                                return;
                            } else {
                                if (DB2 is null || DB2.IsEmpty()) { // Second is empty, reset and make active
                                    SetDB2AsActive();
                                } else { // Both have items, make second first, delete second, reset second and make active
                                    DB1 = DB2;
                                    SetDB2AsActive();
                                }
                                Console.WriteLine("Execution done.");
                            }
                        }
                        break;
                    }
                case 2: {
                        if (!int.TryParse(parts[1], out int num)) { // If 2nd word is not a number
                            Console.WriteLine("Failed to parse numeric part of input, execution failed.");
                        } else {
                            if (parts[0] == "Insert") { // Inserts into active structure
                                ActiveDB.Insert(num);
                                Console.WriteLine("Execution done.");
                                Console.WriteLine(ActiveDB.ToString());
                            }
                        }
                        break;
                    }
                default: {
                        Console.WriteLine("Format invalid, execution failed.");
                        return;
                    }
            }
        }
    }
}
