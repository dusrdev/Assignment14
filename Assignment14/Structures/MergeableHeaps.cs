using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment14.Structures {
    public abstract class MergeableHeaps {
        private LinkedList<int> Lst { get; set; }
        private int Length { get; set; }
        private int Size { get; set; }

        public abstract void MakeHeap();

        public abstract void Insert();

        public abstract int Minimum();

        public abstract int ExtractMin();

        public abstract void Union();
    }
}
