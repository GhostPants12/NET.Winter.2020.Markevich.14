using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BinarySearch
{
    public static class Search
    {
        /// <summary>  Searches for an element by binary search.</summary>
        /// <typeparam name="T">Type of sequence's elements.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="elementToSearch">The element to search.</param>
        /// <returns>Index of found element if it its found, -1 if it isn't.</returns>
        /// <exception cref="System.ArgumentException">Thrown when sequence is not sorted.</exception>
        public static int BinarySearch<T>(this T[] array, T elementToSearch, IComparer<T> comparer = null)
        {
            if (comparer is null)
            {
                comparer = Comparer<T>.Default;
            }

            int left = 0;
            int right = array.Length;

            while (left <= right)
            {
                var middle = (left + right) / 2;

                if (elementToSearch.Equals(array[middle]))
                {
                    return middle;
                }

                if (comparer.Compare(elementToSearch, array[middle]) < 0)
                {
                    right = middle - 1;
                }

                if (comparer.Compare(elementToSearch, array[middle]) > 0)
                {
                    left = middle + 1;
                }
            }

            return -1;
        }
    }
}
