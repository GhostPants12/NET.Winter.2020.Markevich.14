using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinarySearchTreeTests
{
    class StringComparer : IComparer<string>
    {
        public int Compare([AllowNull] string x, [AllowNull] string y) => x.Length == y.Length ? 0 : x.Length > y.Length ? -1 : 1;
    }
}
