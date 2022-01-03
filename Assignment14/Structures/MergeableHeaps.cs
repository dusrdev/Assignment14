using System.Collections.Generic;

namespace Assignment14.Structures {
    /// <summary>
    /// This is the base class for all structures -- OOP is the best approach here 
    /// since this program requires the same functionallity for all data structures
    /// </summary>
    public abstract class MergeableHeaps {
        /// <summary>
        /// The base list
        /// </summary>
        protected LinkedList<int> Lst { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MergeableHeaps() {
            Lst = new LinkedList<int>();
        }

        /// <summary>
        /// Checks if there are any items in the data structure
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() {
            return Lst.Count == 0;
        }

        /// <summary>
        /// Inserts the value in the structure
        /// </summary>
        /// <param name="value"></param>
        public abstract void Insert(int value);

        /// <summary>
        /// Returns the minimum value
        /// </summary>
        /// <returns></returns>
        public abstract int Minimum();

        /// <summary>
        /// Removes the minimum value and returns it
        /// </summary>
        /// <returns></returns>
        public abstract int ExtractMin();

        /// <summary>
        /// Merges this strucure with another of the same type
        /// </summary>
        /// <param name="other"></param>
        public abstract void Union(MergeableHeaps other);

        /// <summary>
        /// Represents the data structure like a set in mathematics
        /// </summary>
        /// <returns></returns>
        public override string ToString() { // simple string representation
            return "{ " + string.Join(',', Lst) + " }";
        }
    }
}
