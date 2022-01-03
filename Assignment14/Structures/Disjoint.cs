namespace Assignment14.Structures {
    internal class Disjoint : MergeableHeaps {
        /// <summary>
        /// Removes the minimum value and returns it
        /// </summary>
        /// <remarks>
        /// Time Complexity => O(n)
        /// </remarks>
        /// <returns></returns>
        public override int ExtractMin() {
            // There is a built-in method which gets the minimum but I'll avoid "cheating"
            if (Lst.Count == 0) { // No values in the heap
                return -1;
            } else { // Not empty
                var min = Lst.First;
                var runner = Lst.First;
                while (runner.Next is not null) {
                    if (runner.Value < min.Value) {
                        min = runner;
                    }
                    runner = runner.Next;
                }
                int minValue = min.Value;
                Lst.Remove(min);
                return minValue;
            }
        }

        /// <summary>
        /// Inserts a new value if doesn't already exist
        /// </summary>
        /// <remarks>
        /// Time Complexity => O(n)
        /// </remarks>
        /// <param name="value"></param>
        public override void Insert(int value) { // check if exists to prevent creating duplicates, if does not exist add first
            var runner = Lst.First;
            while (runner is not null) {
                if (runner.Value == value) {
                    return;
                }
                runner = runner.Next;
            }
            Lst.AddFirst(value);
        }

        /// <summary>
        /// Returns the minimum value
        /// </summary>
        /// <remarks>
        /// Time Complexity => O(n)
        /// </remarks>
        /// <returns></returns>
        public override int Minimum() {
            // There is a built-in method which gets the minimum but I'll avoid "cheating"
            if (Lst.Count == 0) { // No values in the heap
                return -1;
            } else { // Not empty
                var min = Lst.First;
                var runner = Lst.First;
                while (runner.Next is not null) {
                    if (runner.Value < min.Value) {
                        min = runner;
                    }
                    runner = runner.Next;
                }
                return min.Value;
            }
        }

        /// <summary>
        /// Merges other heap into this one
        /// </summary>
        /// <remarks>
        /// Time Complexity => O(m*n)
        /// m -> length of other heap
        /// n -> length of this heap
        /// </remarks>
        /// <param name="other"></param>
        public override void Union(MergeableHeaps other) {
            if (other is not Disjoint otherHeap) {
                return;
            }
            foreach (var newValue in otherHeap.Lst) {
                Insert(newValue);
            }
        }
    }
}
