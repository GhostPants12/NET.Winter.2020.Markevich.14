using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinarySearchTreeTests
{
    class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y) => x == y ? 0 : x > y ? -1 : 1;
    }
}
