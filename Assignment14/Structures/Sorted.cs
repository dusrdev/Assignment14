namespace Assignment14.Structures {
    public class Sorted : MergeableHeaps {
        /// <summary>
        /// Removes the minimum value and returns it
        /// </summary>
        /// <remarks>
        /// Time Complexity => O(1)
        /// </remarks>
        /// <returns></returns>
        public override int ExtractMin() {
            if (Lst.Count == 0) { // If lst1 is empty return -1
                return -1;
            } else {
                var value = Lst.First.Value;
                Lst.RemoveFirst();
                return value;
            }
        }

        /// <summary>
        /// Inserts a new value
        /// </summary>
        /// <remarks>
        /// Time Complexity => O(n)
        /// </remarks>
        /// <param name="value"></param>
        public override void Insert(int value) {
            if (Lst.Count == 0 || value < Lst.First.Value) { // First item to be inserted or smallest yet
                Lst.AddFirst(value);
            } else {
                // iterate until we reach a bigger value or the last node
                // then set the next node to new value
                var temp = Lst.First;
                while (temp.Next is not null && temp.Next.Value < value) {
                    temp = temp.Next;
                }
                Lst.AddAfter(temp, value);
            }
        }

        /// <summary>
        /// Returns the minimum value
        /// </summary>
        /// <remarks>
        /// Time Complexity => O(1)
        /// </remarks>
        /// <returns></returns>
        public override int Minimum() {
            if (Lst.Count == 0) { // If lst1 is null, both are empty so return -1
                return -1;
            } else {
                return Lst.First.Value;
            }
        }

        /// <summary>
        /// Merges new heap to current one
        /// </summary>
        /// <remarks>
        /// Time Complexity => O(m) every value in new heap * O(n) for insertion of value => O(n*m)
        /// </remarks>
        /// <param name="other"></param>
        public override void Union(MergeableHeaps other) {
            if (other is not Sorted otherHeap) { // Check to see if both heaps are the same structure type
                return;
            }
            foreach (var newValue in otherHeap.Lst) { // Insert every value from new heap to this heap
                Insert(newValue);
            }
        }
    }
}
