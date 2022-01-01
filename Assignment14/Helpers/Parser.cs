using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment14.Helpers {
    public class Parser {
        /// <summary>
        /// To make the program simple, it will only read the commands
        /// from a literal "commands.txt" file which needs to be placed in the executable's folder
        /// </summary>
        private readonly string FileName = "commands.txt";

        /// <summary>
        /// Attemps to read commands from a "commands.txt" file in the executable folder.
        /// </summary>
        /// <remarks>
        /// <see langword="false"/> indicates that either the file wasn't found or parsing has failed.
        /// </remarks>
        /// <param name="commands">object which will contain all commands</param>
        public bool ReadCommandsFromFile(out string[] commands) {
            commands = null;

            // Check if the file even exists
            if (!File.Exists(FileName)) {
                return false;
            }

            try {
                var lines = File.ReadAllLines(FileName).ToList(); // Get all lines into a list
                lines.RemoveAll(l => string.IsNullOrWhiteSpace(l)); // Remove all empty lines
                commands = lines.ToArray(); // Convert into array
            } catch {
                return false;
            }

            return true;
        }
    }
}
