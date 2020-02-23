using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BinarySearchTreeTests
{
    class PointComparer : IComparer<Point>
    {
        public int Compare([AllowNull] Point x, [AllowNull] Point y) => x.Y == y.Y ? 0 : x.Y > y.Y ? 1 : -1;
    }
}
