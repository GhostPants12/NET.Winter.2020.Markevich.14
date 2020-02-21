using System;
using System.Collections.Generic;
using System.Text;

namespace EnumerableSequences.Adapters
{
    internal class ComparisonAdapter<TSource> : GenericsDemo.IComparer<TSource>
    {
        private Comparison<TSource> comparison;

        public ComparisonAdapter(Comparison<TSource> comparison)
        {
            this.comparison = comparison;
        }

        public int Compare(TSource lhs, TSource rhs)
        {
            return this.comparison(lhs, rhs);
        }
    }
}
