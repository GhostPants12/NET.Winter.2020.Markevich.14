using System;
using System.Collections.Generic;
using System.Text;
using GenericsDemo;

namespace EnumerableSequences.Adapters
{
    internal class PredicateAdapter<TSource> : IPredicate<TSource>
    {
        private Predicate<TSource> predicate;

        public PredicateAdapter(Predicate<TSource> predicate)
        {
            this.predicate = predicate;
        }

        public bool IsMatch(TSource value)
        {
            return this.predicate(value);
        }
    }
}
